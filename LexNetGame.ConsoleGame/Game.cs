﻿

internal class Game
{
    private Map map = null!;
    private Hero hero = null!;

    public Game()
    {
    }

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true;

        do
        {
            //DrawMap
            DrawMap();

            //GetCommand
            GetCommand();

            //Act

            //DrawMap

            //EnemyAction

            //DrawMap

        } while (gameInProgress);

    }

    private void GetCommand()
    {
        var keyPressed = ConsoleUI.GetKey();

        switch(keyPressed)
        {
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break; 
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break; 
            case ConsoleKey.DownArrow:
                Move(Direction.South);
                break;
        }
    }

    private void Move(Position movement)
    {
        Position newPosition = hero.Cell.Position + movement;
        Cell? newCell = map.GetCell(newPosition);
        if (newCell is not null) hero.Cell = newCell;
    }

    private void DrawMap()
    {
        ConsoleUI.Clear();
        ConsoleUI.Draw(map);

      
    }

    private void Initialize()
    {
        //ToDo read from config
        map = new Map(width: 10, height: 10);
        var heroCell = map.GetCell(0, 0)!;
        hero = new Hero(heroCell);
        map.Creatures.Add(hero);
    }
}