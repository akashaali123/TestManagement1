using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagement1.Model
{
    public class TblQuestionCategoryAndExpMapping
    {
        [Key]
        public int Id { get; set; }

        public int? QuestionId { get; set; }

        public int? CategoryId { get; set; }

        public int? ExpLevelId { get; set; }

    }
}
