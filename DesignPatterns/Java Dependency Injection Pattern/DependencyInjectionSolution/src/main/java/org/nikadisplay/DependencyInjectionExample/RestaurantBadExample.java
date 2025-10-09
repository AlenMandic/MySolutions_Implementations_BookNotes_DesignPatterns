// BAD Example: Tight Coupling, Restaurant class is fully dependenant on a particular instance of Chef
package org.nikadisplay.DependencyInjectionExample;

// BAD: Class ResturantBadExample is tightly coupled to a specific instance of Chef "HeadChefJohn".
// If we want to assign a different chef to work, we need to change our actual code here, which is bad.
// This class should only define that it needs a HeadChef, not exactly which one it needs from exactly where.
public class RestaurantBadExample {

    Chef headChef = new HeadChefAlex();

    public void doWork() {
       headChef.doWork();
    }

}
