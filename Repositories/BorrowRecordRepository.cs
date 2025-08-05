using SimpleLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        public void AddBorrowRecord(BorrowRecord borrowRecord)
        {
            var borrowRecords = GetAllborrowRecords
           borrowRecords.Add(borrowRecord);
            FileContext.SaveborrowRecords(borrowRecords);
        }

        public  borrowRecord GatborrowRecord(int BRId)
        {
            return GetAllborrowRecords().FirstOrDefault(b => b.BRId == BRId);
        }


        public void UpdateborrowRecord(BorrowRecord borrowRecord)
        {
            var borrowRecords = GetAllborrowRecords();
            var index = borrowRecords.FindIndex(b => b.BRId == BRId);
            if (index != -1)
            {
                borrowRecords.[index] = borrowRecord;
                FileContext.SaveborrowRecords(borrowRecords);
            }

        }

        public List<BorrowRecord> GetAllborrowRecords()
        {
            return FileContext.LoadborrowRecords();
        }






    }
}
