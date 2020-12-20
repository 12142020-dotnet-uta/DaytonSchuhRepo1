﻿using System;

namespace DaytonSchuhRepo1
{
    public class Program
    {
        // Creating a class based on our interface.
        class Cat : Animal{
            // Because this class is based on the Animal interface
            // we must implement the animalSound method
            public string animalSound(){
                return "meows";
            }
        }

        class Dog : Animal{
            public string animalSound(){
                return "barks";
            }
        }
        static void Main(string[] args)
        {
            // Creating an object of our Cat class
            Cat c = new Cat();
            // Calling the cat.
            Console.WriteLine($"The {c.GetType().Name} {c.animalSound()} at you.");
            // Creating an object of our Dog class
            Dog d = new Dog();
            // Calling the dog.
            Console.WriteLine($"The {d.GetType().Name} {d.animalSound()} at you.");

            // Bees?
            Console.WriteLine($"The {d.GetType().Name} {c.animalSound()}...?");
        }
    }

    /*******************************************
    *
    * Our interface for animals is below.
    *
    * Interfaces establish can do relationships
    * and simulate inheritance, but they are NOT
    * inheritance.
    *
    *******************************************/
    public interface Animal{
        // An animal "can make" a sound
        string animalSound();

    }
}
