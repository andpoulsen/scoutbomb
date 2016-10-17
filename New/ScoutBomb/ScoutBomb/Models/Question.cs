using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutBomb.Models
{
    public class Question
    {
        public string question { get; set; }
        public Answer[] answers { get; set; }
    }

    public class Answer
    {
        public string answer { get; set; }
        public bool correct { get; set; }
    }
}
