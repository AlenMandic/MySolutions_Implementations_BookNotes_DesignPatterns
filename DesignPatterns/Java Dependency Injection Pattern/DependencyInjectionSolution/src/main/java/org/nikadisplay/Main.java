package org.nikadisplay;

import org.nikadisplay.DependencyInjectionExample.*;
//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {

    public static void main(String[] args) {

        // BAD: Tightly coupled to a specific instance of a new HeadChef;
        RestaurantBadExample ourBadRestaurant = new RestaurantBadExample();
        ourBadRestaurant.doWork();

        // GOOD: Dependency injection pattern via constructor injection! We can change chef as we want with the headChef variable, without changing the code of our good restaurant!
        // When doing Chef headChef = new someChef(); This is called "Programming against Interfaces". If we put HeadChefJohn headChef = new HeadChefAlex... very error prone and bad.
        Chef headChef = new HeadChefJohn();
        RestaurantGoodExample ourGoodRestaurant = new RestaurantGoodExample(headChef);
        ourGoodRestaurant.doWork();
    }
}
