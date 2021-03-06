﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace returnzork.BackupV3_API
{
    public interface BackupV3API
    {
        void Initialize();

        void Work(string[] Imports);


        void Interface();

        string Author();
        string Version();
        string Name();

        int Priority();



        TimeToRun RunTime { get; }
    }

    public enum TimeToRun { Before, After, Both }
}