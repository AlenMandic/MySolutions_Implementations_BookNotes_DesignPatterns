package org.nikadisplay.DependencyInjectionExample;

//GOOD: We accept our interface contract of Chef in the constructor without relying on any specific Chef!
// We can use Alex or John without modifying any of the code here!
public class RestaurantGoodExample {

    private final Chef headChef;

    public RestaurantGoodExample(Chef headChef) {
        this.headChef = headChef;
    }

    public void doWork() {
        headChef.doWork();
    }

}
