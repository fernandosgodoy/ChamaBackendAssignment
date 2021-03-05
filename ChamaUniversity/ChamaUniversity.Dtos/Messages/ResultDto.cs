using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Dtos.Messages
{
    public class ResultDto
    {

        public int InsertedId { get; set; } = 0;
        public bool Success { get; set; } = false;
        public List<string> Messages { get; set; } = new List<string>();

    }
}
