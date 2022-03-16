using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent {
    //Textbook Examples
          public const string ENEMY_HIT = "ENEMY_HIT";
          public const string SPEED_CHANGED = "SPEED_CHANGED";

    //What we will use
    public const string TOP_LEFT = "TOP_LEFT";
    public const string TOP_RIGHT = "TOP_RIGHT";
    public const string BOTTOM_RIGHT = "BOTTOM_RIGHT";
    public const string BOTTOM_LEFT = "BOTTOM_LEFT";

    public const string ANSWER = "ANSWER";
    public const string CORRECT_ANSWER = "CORRECT_ANSWER";
    public const string WRONG_ANSER = "WRONG_ANSWER";

    public const string PAUSE = "PAUSE";
    public const string UNPAUSE = "UNPAUSE";
    public const string PROMPT = "PROMPT";

    //Asteroid Events
    public const string AST_OUT_BOUNDS = "OUT_OF_BOUNDS";
}
