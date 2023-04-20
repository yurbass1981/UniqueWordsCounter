using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordsCounter.Services
{
    internal interface IAppService
    {
        void Run(string filePath, string resultFilePath);
    }
}
