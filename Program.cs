using System;

namespace OPPTask
{
    // 1️⃣ Book class
    class Book
    {
        private string Title;
        private string Author;
        private bool IsBorrowed;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsBorrowed = false;
        }

        public string getTitle() { return Title; }
        public string getAuthor() { return Author; }
        public bool getIsBorrowed() { return IsBorrowed; }

        public void Borrow() { IsBorrowed = true; }
        public void Return() { IsBorrowed = false; }
    }

    // 2️⃣ Interface
    interface IBorrowable
    {
        void BorrowBook(Book book);
        void ReturnBook(Book book);
    }

    // 3️⃣ Abstract Member class
    abstract class Member
    {
        protected string Name;
        protected int MemberId;

        public Member(string name, int memberId)
        {
            Name = name;
            MemberId = memberId;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Name: " + Name + ", Member ID: " + MemberId);
        }

        public string getName() { return Name; }
        public int getMemberId() { return MemberId; }

        public abstract double CalculateLateFee(int daysLate);
    }

    // 4️⃣ StudentMember
    class StudentMember : Member, IBorrowable
    {
        public StudentMember(string name, int memberId) : base(name, memberId) { }

        public void BorrowBook(Book book)
        {
            book.Borrow();
            Console.WriteLine(Name + " borrowed '" + book.getTitle() + "'");
        }

        public void ReturnBook(Book book)
        {
            book.Return();
            Console.WriteLine(Name + " returned '" + book.getTitle() + "'");
        }

        public override double CalculateLateFee(int daysLate)
        {
            return daysLate * 0.5;
        }
    }

    // 5️⃣ TeacherMember
    class TeacherMember : Member, IBorrowable
    {
        public TeacherMember(string name, int memberId) : base(name, memberId) { }

        public void BorrowBook(Book book)
        {
            book.Borrow();
            Console.WriteLine(Name + " borrowed '" + book.getTitle() + "'");
        }

        public void ReturnBook(Book book)
        {
            book.Return();
            Console.WriteLine(Name + " returned '" + book.getTitle() + "'");
        }

        public override double CalculateLateFee(int daysLate)
        {
            return daysLate * 0.2;
        }
    }

    // 6️⃣ Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // إنشاء الكتب
            Book book1 = new Book("C# Basics", "John Doe");
            Book book2 = new Book("OOP in Depth", "Jane Smith");

            Console.WriteLine("Book '" + book1.getTitle() + "' by " + book1.getAuthor() + " created.");
            Console.WriteLine("Book '" + book2.getTitle() + "' by " + book2.getAuthor() + " created.");

            // إنشاء الأعضاء
            StudentMember student = new StudentMember("Ahmed", 101);
            TeacherMember teacher = new TeacherMember("Sara", 201);

            // استعارة الكتب
            student.BorrowBook(book1);
            teacher.BorrowBook(book2);

            // إعادة الكتب متأخرة + حساب الغرامة
            int studentLateDays = 4;
            student.ReturnBook(book1);
            double studentPenalty = student.CalculateLateFee(studentLateDays);
            Console.WriteLine(student.getName() + " returned '" + book1.getTitle() + "' " + studentLateDays + " days late. Penalty: " + studentPenalty + " JOD.");

            int teacherLateDays = 5;
            teacher.ReturnBook(book2);
            double teacherPenalty = teacher.CalculateLateFee(teacherLateDays);
            Console.WriteLine(teacher.getName() + " returned '" + book2.getTitle() + "' " + teacherLateDays + " days late. Penalty: " + teacherPenalty + " JOD.");
        }
    }
}
