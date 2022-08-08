﻿using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameSettings
{
    public SystemLanguage language = SystemLanguage.English;
    public List<string> songDirs = new List<string>() {"C:/NOWSHIN/Unity Projects/Play-master/UltraStar Play/Assets/Songs/" };
}
