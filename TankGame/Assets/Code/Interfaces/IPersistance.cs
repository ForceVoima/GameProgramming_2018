﻿namespace TankGame.Persistance
{
    public interface IPersistance
    {
        // File extension of the save file
        string Extension { get; }

        // The path of the save file on disk.
        string FilePath { get; }

        // A generic method for serializing the game data and storing it to the disk.
        void Save<T>(T data);
        
        // A method for reading serialized data from file and deserializing it.
        T Load<T>();
    }
}
