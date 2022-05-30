﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class CacheSettings
    {
        public List<ObservableDirectory> ObservableDirectories { get; set; }
        public List<string> ObservableFiles { get; private set; }

        public CacheSettings()
        {
            ObservableDirectories = new List<ObservableDirectory>();
            ObservableFiles = new List<string>();
        }
    }
}