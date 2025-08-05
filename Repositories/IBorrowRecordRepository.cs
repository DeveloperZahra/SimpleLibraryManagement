using SimpleLibraryManagement.Models;

namespace SimpleLibraryManagement.Repositories
{
    public interface IBorrowRecordRepository
    {
        void AddBorrowRecord(BorrowRecord borrowRecord);
        borrowRecord GatborrowRecord(int BRId);
        List<BorrowRecord> GetAllborrowRecords();
        void UpdateborrowRecord(BorrowRecord borrowRecord);
    }
}