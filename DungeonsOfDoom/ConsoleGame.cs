using System;
using DungeonsOfDoom.Core;
using DungeonsOfDoom.Core.Characters;
using DungeonsOfDoom.Items;
using DungeonsOfDoom.Utils;

namespace DungeonsOfDoom
{
    class ConsoleGame
    {
        Player player;
        Room[,] world;

        public void Play()
        {
            GameStarting();
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayWorld();
                DisplayStats();
                AskForMovement();
                //the game runs as long as the player is alive and there are still monsters on the map
            } while (player.IsAlive && Monster.MonsterCount > 0);

            GameOver();
            
        }
        // creates a player with 30 health and coordinates 0,0
        private void CreatePlayer()
        {
            player = new Player(30, 0, 0);
        }
        // creates world and using radomUtils generating either a monster or a item
        private void CreateWorld()
        {
            world = new Room[20, 5];
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    int percentage = RandomUtils.Percentage();
                    if (percentage < 5)
                        world[x, y].Monster = new Ogre();
                    else if (percentage < 10)
                        world[x, y].Monster = new Skeleton();
                    else if (percentage < 15)
                        world[x, y].Item = new Potion();
                    else if (percentage < 20)
                        world[x, y].Item = new Sword();
                }
            }
        }
        // prints the player, monster, item or empty room to the console.
        
        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    //every dot represents a room
                    //every M represents a monster
                    //every I represents a random item sword or potion
                    // P represents the player
                    if (player.X == x && player.Y == y)
                        Console.Write("P");
                    else if (room.Monster != null)
                        Console.Write("M");
                    else if (room.Item != null)
                        Console.Write("I");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }
        // Prints players health and backback into the console
        
        private void DisplayStats()
        {
            Console.WriteLine($"\nMonsters Remaining {Monster.MonsterCount}");
            Console.WriteLine($"Obtainable items {Item.ItemCount}");
            Console.WriteLine($"Health: {player.Health}\n");
            Console.WriteLine("Player Backpack");
            foreach (var item in player.Backpack)
            {
                Console.WriteLine(item.Name);
            }
        }

        // sets the controller keys
        private void AskForMovement()
        {
            int newX = player.X;
            int newY = player.Y;
            bool isValidKey = true;

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidKey = false; break;
            }
            // checks so that the player cant move outside the world
            if (isValidKey &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;
            }
            EnterRoom();
        }

        // prints the different scenarios depending on what the player faces inside the room
        private void EnterRoom()
        {
            Room currentRoom = world[player.X, player.Y];
            Monster monster = currentRoom.Monster;
 
            if (monster != null)
            {
               AttackResult result = monster.Attack(player);
               TextAnimator.AnimateText($"({monster.Name}) Health ({result.Attacker.Health}) damage player by {result.Damage}", 50);

               // Console.WriteLine($"({monster.Name}) Health ({result.Attacker.Health}) damage player by {result.Damage}");
                Console.ReadKey(true);


                //skeleton wont attack player if player are to healty, it will insted deal no damage and try to run away
                if(result.Damage == 0)
                {
                    TextAnimator.AnimateText("\nSkeleton tries to run away", 50);
                    Console.ReadKey();
                }
                
                // if player survived the attack or the skeleton tries to run away the player will fight back
                if (player.IsAlive)
                {

                    result =  player.Attack(monster);

                    foreach (var item in player.Backpack)
                    {
                        if (item.Name == "Sword")
                        {
                            result.Damage += 5;
                        }
                    }
                    TextAnimator.AnimateText($"\nPlayer Damage Monster by {result.Damage}", 50);
                    //Console.WriteLine($"\nPlayer Damage Monster by {result.Damage}");
                    Console.ReadKey();
                }

                // if the monster died, the monster will be added to the backpack
                if (!monster.IsAlive)
                {
                    TextAnimator.AnimateText($"\n{currentRoom.Monster.Name} added to backpack", 50);
                    Console.ReadKey();
                    player.Backpack.Add(currentRoom.Monster);
                    currentRoom.Monster = null;
                }
            }

            // if there is a item in the current room the player steps into the item will be added to the backpack
            // however the item will be used on pickup, so in this case its more of a notice that the item have been picked up
            // might fix later
            if(currentRoom.Item != null)
            {
                TextAnimator.AnimateText($"{currentRoom.Item.Name} added to backpack", 50);
                player.Backpack.Add(currentRoom.Item);
                currentRoom.Item.Use(player);
                currentRoom.Item = null;
            }
        }
        // the gameOver method prints a player wins message if there is no more monsters on the map
        // prits You Died if player died and the game is over...
        // if key is pressed the game restarts
        private void GameOver()
        {
            Console.Clear();
            if (Monster.MonsterCount == 0)
            {
                TextAnimator.AnimateText("You have defeted all mosnters", 50);
                TextAnimator.AnimateText("Hero wins!", 50);
                Console.ReadKey();
                Play();
            }
            else if (!player.IsAlive)
                TextAnimator.AnimateText("You Died", 50);
            Console.ReadKey();
            Play();
        }

        // a message before games starts
        private void GameStarting()
        {
            TextAnimator.AnimateText("Welsome to dungeons of Doom\nKill all monsters!\nObtain items\n", 50);
            TextAnimator.AnimateText("Good luck Hero", 50);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
