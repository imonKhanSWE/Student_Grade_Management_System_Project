using System;

// STUDENT STRUCTURE
struct Student
{
    public string Name;
    public int[] Marks; //Array to store marks for Multiple Subjects
    public int SubjectCount;
}

//CONSTANTS
class Program
{
    //CONSTANTS & GLOBAL SCOPE
    const int MAX_STUDENTS = 50;
    const int MAX_SUBJECTS = 5; 
    const int PASSING_GRADE = 40; //mark needed to pass

    //GLOBAL ARRAY FOR STUDENTS
    private static Student[] Students = new Student[MAX_STUDENTS]; //Array to store students
    static int StudentCount = 0;

    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║     STUDENT GRADE MANAGEMENT SYSTEM        ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.ResetColor();

        bool running = true;
        while (running)
        {
            DisplayMenu();
            string? choice = Console.ReadLine();

            // Switch statement for menu selection
            switch (choice)
            {
                case "1":
                    AddNewStudent(ref StudentCount);
                    break;
                case "2":
                    EnterMarks(ref StudentCount);
                    break;

                case "3":
                    SearchAndDisplayStudent(StudentCount);
                    break;

                case "4":
                    DisplayAllStudents(StudentCount);
                    break;

                case "5":
                    UpdateStudentMarks(ref StudentCount);
                    break;

                case "6":
                    running = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Thank you for using Student Grade Management System!");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Invalid choice! Please try again.");
                    Console.ResetColor();
                    break;
            }

        }
    }

    // ===== METHODS SECTION =====
    static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n╔════════════ MAIN MENU  ════════════╗");
        Console.WriteLine("║ 1. Add New Student                 ║");
        Console.WriteLine("║ 2. Enter/Update Marks              ║");
        Console.WriteLine("║ 3. Search Student by Name          ║");
        Console.WriteLine("║ 4. Display All Students            ║");
        Console.WriteLine("║ 5. Update Marks for Existing       ║");
        Console.WriteLine("║ 6. Exit                            ║");
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.ResetColor();
        Console.Write("Enter your choice (1-6): ");
    }

    //METHOD: Add a new student (using ref parameter to modify studentCount)
    static void AddNewStudent(ref int count)
    {
        if(count > MAX_STUDENTS)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Cannot add more students. Maximum limit reached!");
            Console.ResetColor();
            return;
        }

        Console.Write("\nEnter student name: ");
        string? name = Console.ReadLine();

        //Validate name input
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Name can not be null or empty.");
            Console.ResetColor();
            return;
        }

        //Check if student already exists
        for (int i = 0; i<count; i++)
        {
            if (Students[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Student '{name}' already exists!");
                Console.ResetColor();
                return;
            }
        }

        //Get number of students (Validation with TryParse)
        Console.Write("Enter number of subject (1-5): ");
        int subjectCount = 0;
        while (!int.TryParse(Console.ReadLine(), out subjectCount) || subjectCount < 1 || subjectCount > MAX_SUBJECTS)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" Invalid input! Please enter a number between 1 and {MAX_SUBJECTS}");
            Console.ResetColor();
            Console.Write(" Enter number of subjects (1-5): ");
        }

        //Initilize Student
        Students[count].Name = name;
        Students[count].SubjectCount = subjectCount;
        Students[count].Marks = new int[subjectCount];

        //Using ref to modify the count variable
        count++;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" Student '{name}' added successfully!");
        Console.ResetColor();
    }


    //METHOD: Enter marks for a student
    static void EnterMarks(ref int count)
    {
        if(count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" No students added yet!");
            Console.ResetColor();
            return;
        }

        Console.Write("\nEnter student name to enter marks: ");
        string? searchName = Console.ReadLine();

        //Loop through students to find the one
        for(int i = 0; i < count; i++)
        {
            if (Students[i].Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nEntering mark for {Students[i].Name} ({Students[i].SubjectCount} subjects): ");

                //Loop through subjects
                for(int j = 0; j < Students[i].SubjectCount; j++)
                {
                    Console.Write($"   Subject {j + 1} marks (0-100): ");

                    //Validate marks input using TryParse
                    int marks = 0;
                    while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Invalid input! Enter marks between 0 and 100");
                        Console.ResetColor();
                        Console.Write($"   Subject {j + 1} marks (0-100): ");
                    }

                    Students[i].Marks[j] = marks;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Marks entered successfully!");
                Console.ResetColor ();
                return;
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" Student '{searchName}' not found!");
        Console.ResetColor ();

    }

    //METHOD: Search and display a specific student using out parameter
    static void SearchAndDisplayStudent(int count)
    {
        if(count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" No students in the system!");
            Console.ResetColor();
            return;
        }

        Console.Write("\nEnter student name to search: ");
        string? searchName = Console.ReadLine();

        //Loop through students to find the one
        for (int i = 0; i < count; i++)
        {
            if (Students[i].Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                DisplayStudentDetails(Students[i]);
                return;
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" Student '{searchName}' not found!");
        Console.ResetColor();
    }

    // METHOD: Display details of a single student (using out parameters)
    static void DisplayStudentDetails(Student student)
    {
        // Calculate total and average using out parameters
        CalculateTotalAndAverage(student, out int total, out double average);
        string grade = CalculateGrade(average);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n╔════════════╣ STUDENT DETAILS ╠══════════════╗");
        Console.WriteLine($"║ Name: {student.Name.PadRight(37)} ║");
        Console.WriteLine($"║ Subjects: {student.SubjectCount.ToString().PadRight(34)}║");

        //Display individual marks
        Console.Write("║ Marks: ");
        for (int i = 0; i < student.SubjectCount; i++)
        {
            Console.Write($"{student.Marks[i]} ");
        }
        Console.WriteLine(new string(' ', 30 - (student.SubjectCount * 3)) + "       ║");

        Console.WriteLine($"║ Total Marks: {total.ToString().PadRight(31)}║");
        Console.WriteLine($"║ Average: {average:F2}%{new string(' ', 28)} ║");
        Console.WriteLine($"║ Grade: {grade.PadRight(37)}║");
        Console.WriteLine($"╚═════════════════════════════════════════════╝");
        Console.ResetColor();
    }

    // METHOD: Calculate total and average (using out parameters to return multiple values)
    static void CalculateTotalAndAverage(Student student, out int total, out double  average)
    {
        total = 0;

        //Loop through all marks and calculate total
        for (int i = 0; i < student.SubjectCount; i++)
        {
            total += student.Marks[i];
        }

        //Calculate average wtih typical operator usage
        average = (double)total / student.SubjectCount;
    }


    // METHOD: Calculate grade based on average (if-else for grading logic)
    static string CalculateGrade(double average)
    {
        if (average >= 80)
            return "A";
        else if (average >= 70)
            return "B";
        else if (average >= 60)
            return "C";
        else if (average >= PASSING_GRADE)
            return "D";
        else
            return "Fail";
    }

    // METHOD: Display all students
    static void DisplayAllStudents(int count)
    {
        if (count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" No students in the system!");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n╔════════════════════ ALL STUDENTS ══════════════════╗");
        Console.ResetColor();

        //Loop through all Students
        for (int i = 0; i < count; i++)
        {
            CalculateTotalAndAverage(Students[i], out int total, out double average);
            string grade = CalculateGrade(average);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n#{i + 1}. {Students[i].Name}");
            Console.ResetColor();
            Console.WriteLine($"   Total: {total} | Average: {average:F2}% | Grade: {grade}");
        }
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n╚════════════════════════════════════════════════════╝");
        Console.ResetColor();
    }


    // METHOD: Update marks for an existing student (using ref parameter)
    static void UpdateStudentMarks(ref int count)
    {
        if (count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" No students in the system!");
            Console.ResetColor();
            return;
        }

        Console.Write("\nEnter student name to update marks: ");
        string? searchName = Console.ReadLine();

        //Search for student
        for (int i = 0; i < count; i++)
        {
            if (Students[i].Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nUpdating marks for {Students[i].Name}:");

                // Loop through subjects to update marks
                for (int j = 0; j < Students[i].SubjectCount; j++)
                {
                    Console.Write($"   Subject {j + 1} current marks: {Students[i].Marks[j]}, enter new marks (0-100): ");

                    int newMarks = 0;
                    while (!int.TryParse(Console.ReadLine(), out newMarks) || newMarks < 0 || newMarks > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Invalid input! Enter marks between 0 and 100");
                        Console.ResetColor();
                        Console.Write($"   Subject {j + 1} marks (0-100): ");
                    }

                    Students[i].Marks[j] = newMarks;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Marks updated successfully!");
                Console.ResetColor ();
                return;
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" Student '{searchName}' not found!");
        Console.ResetColor ();
    }

}