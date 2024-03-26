using System;
using Microsoft.Xna.Framework;

public static class Camera{
    public static void Update(Vector2 playerOffset, ref Vector2 scenePosition){
        scenePosition.X += (int)playerOffset.X;
        scenePosition.Y += (int)playerOffset.Y;
        Console.WriteLine(scenePosition);
    }
}
