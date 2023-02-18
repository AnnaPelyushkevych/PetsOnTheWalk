using GenericList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> petsOnTheWalk = new List<string>();
            var allOwners = GetOwners();

            //Giving pets for a walk
            foreach (var p in allOwners)
            {
                GivePetsForAWalk(p.OwnersPets, petsOnTheWalk);
            }
            
            Random r = new Random();
            
            //petsOnTheWalk.Remove("Bob");

            try
            {
                while (petsOnTheWalk.Count != 0)
                {
                    //Randomly get owner to call a pet
                    int index = r.Next(0, allOwners.Count);
                    var owner = allOwners[index];

                    //foreach (var p in owner.OwnersPets)
                    //{
                    //    if (p.IsOnTheWalk)
                    //    {
                    //        p.IsOnTheWalk = false;

                    //        if (!petsOnTheWalk.Remove(p.PetName))
                    //        {
                    //            throw new Exception("Try to remove pet that isn't on a walk");
                    //        }
                    //        break;
                    //    }
                    //}

                    //LINQ
                    var ownerPetsOnTheWalk = from p in owner.OwnersPets
                                             where p.IsOnTheWalk
                                             select p;

                    if (ownerPetsOnTheWalk.Any())
                    {
                        var petFirst = ownerPetsOnTheWalk.First();
                        petFirst.IsOnTheWalk = false;
                        if (!petsOnTheWalk.Remove(petFirst.PetName))
                        {
                            throw new Exception("Try to remove pet that isn't on a walk");
                        }
                    }
                }   
                Console.WriteLine("All pets are at home"); 
            }
             
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            };
        }

        static void GivePetsForAWalk(List<Pet> pets, List<string> walkingPets)
        {
            foreach (var pet in pets)
            {
                walkingPets.Add(pet.PetName);
                pet.IsOnTheWalk = true;

            }
        }

        static List<Owner> GetOwners()
        {
            var owners = new List<Owner>();

            var ownerAnna = new Owner()
            {
                OwnerName = "Anna",
                OwnersPets = new List<Pet>()
                {
                    new Pet() { PetName = "Bars", IsOnTheWalk = false },
                    new Pet() { PetName = "Alf", IsOnTheWalk = false },
                    new Pet() { PetName = "Micka", IsOnTheWalk = false },
                    new Pet() { PetName = "Lialia", IsOnTheWalk = false}
                }
            };

            owners.Add(ownerAnna);

            var ownerMaria = new Owner()
            {
                OwnerName = "Maria",
                OwnersPets = new List<Pet>()
                {
                    new Pet() { PetName = "Charlie", IsOnTheWalk = false },
                    new Pet() { PetName = "Mafi", IsOnTheWalk = false },
                    new Pet() { PetName = "Bob", IsOnTheWalk =false },
                }
            };
            owners.Add(ownerMaria);

            return owners;
        }
    }
}
