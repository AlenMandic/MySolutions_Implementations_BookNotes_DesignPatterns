// HELPER LOGGER: Unit2
unit Example;

interface

uses
Vcl.StdCtrls;

type
TLogHandler = procedure(const msg: String) of object; // Our main type of procedure-logic for our Logger.

procedure Logger(const msg: String); // Main Logger procedure. Sends the message to the subscriber.
procedure SetLogHandler(AHandler: TLogHandler); // Sets variable AHandler: TLogHandler to whoever wants to subscribe

implementation

var
LogHandler: TLogHandler;

// Call the subscriber to output message. Subscriber here would be a Form1.Logger function which logs to a Form1 UI-element (memo).
procedure Logger(const msg: String);
begin
If Assigned(LogHandler) then
LogHandler(msg);
end;

// Set subscriber procedure to handle log outputting. SetLogHandler(Form1.Logger: TLogHandler);
procedure SetLogHandler(AHandler: TLogHandler);
begin
LogHandler := AHandler;
end;

end.


// Unit1: Main form with TForm1

unit Unit1;

interface

Memo1_Debugger: TMemo;

uses
Example // ( Unit2 )

type
 TForm1 = class(TForm)
    procedure Log(const Msg: String);

procedure Log( const Msg: String);
begin

Memo1_Debugger.Lines.Add(msg);

end;

// Inside FormCreate
Unit2.SetLogHandler(Log);

// Now we can use Logger('some log') anywhere beacuse we imported Unit2 in the uses clause
Logger('some msg') // streams 'some msg' to TForm1.Log procedure which outputs it to our Memo debugger.
