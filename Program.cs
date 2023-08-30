using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Animal
    {

        public string Nickname { set; get; }
        public int Age { set; get; }
        public string Gender { set; get; }
        public int Energy { set; get; }
        public int Price { set; get; }
        public int MealQuality { set; get; }

        public Animal(string nickname, int age, string gender, int energy, int price, int mealQuality)
        {
            Nickname = nickname;
            Age = age;
            Gender = gender;
            Energy = energy;
            Price = price;
            MealQuality = mealQuality;
        }

    }

//==================================================================================
    public class Petshop
    {

        public Animal[] animals;
        public Petshop()
        {
            animals = new Animal[15];
        }

        public void AddAnimal(Animal animal)
        {
            for (int i = 0; i < animals.Length; i++)
            {
                if (animals[i] == null)
                {
                    animals[i] = animal;
                    Console.WriteLine(animal.Nickname + " Ad elave olundu.");
                    Console.WriteLine(animal.Age + " Yas elave olundu.");
                    Console.WriteLine(animal.Gender + " Gender elave olundu.");
                    Console.WriteLine(animal.Energy + " Energy elave olundu. ");
                    Console.WriteLine(animal.Price + " Price elave olundu.");
                    Console.WriteLine(animal.MealQuality + " Yemek elave olundu.");
                    Console.WriteLine("+--------------------------------+");
                    return;
                }
            }

            Console.WriteLine("PetShop doludur , heyvaniniz elave edile bilmedi.");
        }

        public void DeleteAnimal(string nickname)
        {
            for (int i = 0; i < animals.Length; i++)
            {
                if (animals[i] != null && animals[i].Nickname == nickname)
                {
                    Console.WriteLine(animals[i].Nickname + " silindi.");
                    animals[i] = null;
                    return;
                }
            }

            Console.WriteLine("Heyvan tapilmadi.");
        }

        public void AddFood(string nickname, int mealQuality)
        {
            foreach (var animal in animals)
            {
                if (animal != null && animal.Nickname == nickname)
                {
                    animal.MealQuality = mealQuality;

                    if (mealQuality == 3)
                        animal.Energy += 3;
                    else if (mealQuality == 2)
                        animal.Energy += 2;
                    else if (mealQuality == 1)
                        animal.Energy += 1;

                    Console.WriteLine("Yemek yenilendi. Yeni enerji seviyesi: " + animal.Energy);
                    return;
                }
            }

            Console.WriteLine("Heyvan tapilmadi.");
        }

        public void Total(out int totalMeal, out int totalPrice)
        {
            totalMeal = 0;
            totalPrice = 0;

            foreach (var animal in animals)
            {
                if (animal != null)
                {
             
                    totalMeal += animal.MealQuality;
                    totalPrice += animal.Price;
                }
            }
        }
        public void ListAnimals()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n=========================");
            Console.WriteLine("PetShopdaki heyvanlar:");
            foreach (var animal in animals)
            {
                if (animal != null)
                {
                    Console.WriteLine(
                        "Ad: " + animal.Nickname + 
                        "\n Yaş: " + animal.Age +
                         "\n Gender: " + animal.Gender +
                          "\n Energy: " + animal.Energy +
                           "\n Price: " + animal.Price+
                           "\n Meal Quality: " + animal.MealQuality +
                           "\n================");
                }
            }
        }


    }
//==================================================================================
    public class Cat : Animal
    {
        public Cat(string nickname, int age, string gender, int energy, int price, int mealQuality) :
            base(nickname, age, gender, energy, price, mealQuality)
        {
        }
    }

    public class Dog : Animal
    {
        public Dog(string nickname, int age, string gender, int energy, int price, int mealQuality) :
            base(nickname, age, gender, energy, price, mealQuality)
        {
        }
    }

    public class Fish : Animal
    {
        public Fish(string nickname, int age, string gender, int energy, int price, int mealQuality) :
            base(nickname, age, gender, energy, price, mealQuality)
        {
        }
    }

    public class Bird : Animal
    {
        public Bird(string nickname, int age, string gender, int energy, int price, int mealQuality) :
            base(nickname, age, gender, energy, price, mealQuality)
        {
        }
    }

//==================================================================================

    public class AnimalAdress
    {
        static void Main(string[] args)
        {
            Petshop petShop = new Petshop();
           
            Cat cat1 = new Cat("Messi", 3,"British",3,250,4);
            Cat dog1 = new Cat("Leo", 3,"Buldog",2,50,5);
            Cat fish1 = new Cat("Rex", 3,"Papuqay",3,650,4);
            Cat bird1 = new Cat("Neymar", 3,"Qizilbaliq",3,350,4);
            Cat dog2 = new Cat("Leo", 3, "Coban iti", 3, 165, 6);

            petShop.AddAnimal(cat1);
            petShop.AddAnimal(dog1);
            petShop.AddAnimal(fish1);
            petShop.AddAnimal(bird1);
            petShop.AddAnimal(dog2);

            petShop.ListAnimals();

            int totalFood, totalPrice;
            petShop.Total(out totalFood, out totalPrice);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total price: " + totalPrice);
            Console.WriteLine("Total meal: " + totalFood);
            Console.WriteLine("===================");

            Console.ReadLine();
        }
    }

}
