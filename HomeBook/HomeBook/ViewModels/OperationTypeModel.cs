﻿namespace HomeBook.ViewModels
{
    using HomeBook.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OperationTypeModel
    {
        public OperationTypeModel()
        {
        }

        public OperationTypeModel(OperationType type)
        {
            this.OperationTypeId = type.OperationTypeId;
            this.Name = type.Name;
        }

        public int OperationTypeId { get; set; }

        public string Name { get; set; }
    }
}
