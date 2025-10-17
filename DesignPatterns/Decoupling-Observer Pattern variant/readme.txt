This is a problem i came across and had to solve while programming in Delphi 12 / Object Pascal.


I have a main program Form: TForm1 which has it's own methods and UI-elements ( A memo i'm specifically using for to output logs for debugging ) tied to it's lifecycle. Inside the program there are regular public methods not tied to TForm1, such as an enumeration-helper function EnumFindWindows. ( a callback-helper to be passed into the Windows api EnumWindows(@CallBack, @DataContext) ).

The issue arised when i tried to pass a simple logger function belonging to TForm1 -> TForm.Log(const Msg1: String) to the function EnumFindWindows, which doesn't belong to TForm1. This means in order for the logger to work i would have to tightly couple it to the TForm1 instance, which is not good, EnumFindWindows should not depend or interact with TForm1 in any way.

So i created a separate helper Unit ( Unit2  ) which would contain a global Logger that merely broadcasts an output Log message to anyone who subscribes to it; without depending on any Form or UI-element belonging to a form.

Inside this Logger unit, we would define a definition type for our basic Logger logic, which we expect anyone trying to subscribe to the logger to implement:

type TLogHandler = procedure (const Msg: String);

Our interface would also define 2 procedures which we need:

procedure Logger(const Msg: String); // Main Logger procedure. Sends the output message to subscribed handler. --> ( TForm1.Log ).

procedure SetLogHandler( AHandler: TLogHandler ) // Subscribe procedure. TForm1 should define a Log procedure which follows our definition, and then we set it as the handler.

implementation

var LogHandler: TLogHandler; // This is nil until initialized

procedure Logger(const Msg: String)
begin

If Assigned(LogHandler) // If someone is subscribed and implementing the logger
LogHandler(msg);

end;

procedure SetLogHandler( AHandler: TLogHandler );
begin

// Allow for someone to subscribe and output messages to their logger
LogHandler := AHandler;

end;

Then inside the main program Form TForm1, we define a regular log function which streams messages to a UI memo element for the compiled debug version of our program: ( important; we now add Unit2 helper Unit to our Uses clause )


type TForm1
  procedure Log(const Msg: String);

implemenation

// Simple TForm1.Log which streams messages to a UI element ( Memo1_Debugger )
procedure Log(const Msg: STring);
begin
 Memo1_Debugger.Lines.Add(FormatDateTime('hh:nn:ss', Now) + '-' + Msg);
end;

And now we can use the Logger anywhere we want without any dependencies by doing:
TForm1.Create --> Unit2.SetLogHandler(Log);

EnumFindWindow --> Logger('Some debug message'); --> This streams to our regular Log procedure and then to the memo...
