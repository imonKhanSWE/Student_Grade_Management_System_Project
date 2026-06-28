# 📚 Student Grade Management System

## Project Overview

A comprehensive **Console Application** built in **C# (.NET 10)** that demonstrates all fundamental C# concepts through a practical student grade management system.

---

## 🎯 Features

### Core Functionality
1. **Add New Student** - Register students with their name and number of subjects
2. **Enter Marks** - Input marks (0-100) for each student's subjects
3. **Search Student** - Find and display a specific student's details
4. **View All Students** - Display summary of all students with grades
5. **Update Marks** - Modify existing student marks
6. **Exit** - Gracefully close the application

### Validation Features
- Duplicate student name prevention
- Input validation using `TryParse()`
- Marks range validation (0-100)
- Subject count validation (1-5)
- Empty input handling

### Grading System
- **Grade A**: Average ≥ 80%
- **Grade B**: Average ≥ 70%
- **Grade C**: Average ≥ 60%
- **Grade D**: Average ≥ 40%
- **Fail**: Average < 40%

---

## C# Fundamentals Covered

### 1. **Variables & Constants**
```csharp
const int MAX_STUDENTS = 50;
const int MAX_SUBJECTS = 5;
const int PASSING_GRADE = 40;
```

### 2. **Data Types**
```csharp
struct Student  // Custom data type
{
	public string Name;
	public int[] Marks;     // Integer array
	public int SubjectCount;
}
```

### 3. **Operators**
- Assignment: `count++`, `name = input`
- Arithmetic: `total += marks`, `(double)total / count`
- Comparison: `average >= 80`, `count < MAX_STUDENTS`
- Logical: `&&`, `||` in conditions

### 4. **Control Flow**

#### If-Else (Grading Logic)
```csharp
if (average >= 80)
	return "A";
else if (average >= 70)
	return "B";
else if (average >= 60)
	return "C";
// ... more conditions
```

#### Switch (Menu Selection)
```csharp
switch (choice)
{
	case "1": AddNewStudent(ref studentCount); break;
	case "2": EnterMarks(ref studentCount); break;
	// ... more cases
}
```

#### Loops

**For Loop** - Iterating through students/subjects:
```csharp
for (int i = 0; i < count; i++)
{
	students[i].Name = name;
}
```

**While Loop** - Input validation:
```csharp
while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
{
	Console.WriteLine("Invalid input!");
}
```

### 5. **Methods**
All methods demonstrate proper design patterns:

```csharp
static void AddNewStudent(ref int count)          // ref parameter
static void CalculateTotalAndAverage(             // out parameters
	Student student, 
	out int total, 
	out double average)
static string CalculateGrade(double average)      // return value
static void DisplayMenu()                         // void method
```

### 6. **Parameters**

**ref Parameter** - Modifies original variable:
```csharp
AddNewStudent(ref studentCount);  // Increases count
```

**out Parameter** - Returns multiple values:
```csharp
CalculateTotalAndAverage(student, out int total, out double average);
// Both total and average are assigned inside the method
```

### 7. **Arrays**

**Static Arrays:**
```csharp
private static Student[] students = new Student[MAX_STUDENTS];
```

**Dynamic Arrays:**
```csharp
students[i].Marks = new int[subjectCount];  // Size determined at runtime
```

### 8. **Strings**
- Input handling: `Console.ReadLine()`
- String comparison: `StringComparison.OrdinalIgnoreCase`
- String formatting: `$"Student '{name}' added"`
- Padding: `student.Name.PadRight(37)`

### 9. **Scope**

**Class-Level Scope** (Static members):
```csharp
private static Student[] students;  // Accessible throughout class
```

**Method-Level Scope** (Local variables):
```csharp
void Method()
{
	string name = "John";  // Only visible in this method
}
```

### 10. **Input Validation**

**TryParse Method:**
```csharp
int.TryParse(Console.ReadLine(), out int marks)
```
Returns `true` if conversion succeeds, `false` otherwise.

---

## Code Structure

```
Program.cs
├── Using Statements
├── Student Struct
├── Program Class
│   ├── Constants (MAX_STUDENTS, MAX_SUBJECTS, etc.)
│   ├── Static Fields (students array, studentCount)
│   ├── Main() Method
│   └── Methods
│       ├── DisplayMenu()
│       ├── AddNewStudent()
│       ├── EnterMarks()
│       ├── SearchAndDisplayStudent()
│       ├── DisplayStudentDetails()
│       ├── CalculateTotalAndAverage()
│       ├── CalculateGrade()
│       ├── DisplayAllStudents()
│       └── UpdateStudentMarks()
```

---

## 📋 How to Use

### Step 1: Start the Application
Run the program in Visual Studio or terminal:
```powershell
dotnet run
```

### Step 2: Main Menu
```
╔════════════ MAIN MENU ════════════╗
║ 1. Add New Student                 ║
║ 2. Enter/Update Marks              ║
║ 3. Search Student by Name          ║
║ 4. Display All Students            ║
║ 5. Update Marks for Existing       ║
║ 6. Exit                            ║
╚════════════════════════════════════╝
```

### Step 3: Example Workflow

**Add a Student:**
```
Choose option: 1
Enter student name: John Doe
Enter number of subjects (1-5): 3
✅ Student 'John Doe' added successfully!
```

**Enter Marks:**
```
Choose option: 2
Enter student name to enter marks: John Doe
Subject 1 marks (0-100): 85
Subject 2 marks (0-100): 90
Subject 3 marks (0-100): 78
✅ Marks entered successfully!
```

**View Student Details:**
```
Choose option: 3
Enter student name to search: John Doe

╔════════════╣ STUDENT DETAILS ╠════════════╗
║ Name: John Doe                           ║
║ Subjects: 3                              ║
║ Marks: 85 90 78                          ║
║ Total Marks: 253                         ║
║ Average: 84.33%                          ║
║ Grade: A                                 ║
╚════════════════════════════════════════════╝
```

---

## 🔍 Key Learning Points

| Topic | Example | Purpose |
|-------|---------|---------|
| **Variables** | `int studentCount = 0;` | Store changing data |
| **Constants** | `const int MAX_STUDENTS = 50;` | Store fixed values |
| **Arrays** | `Student[] students` | Manage collections |
| **Structs** | `struct Student` | Group related data |
| **Methods** | `AddNewStudent()` | Reusable code blocks |
| **ref** | `ref int count` | Modify original variable |
| **out** | `out int total` | Return multiple values |
| **if-else** | Grade assignment | Conditional logic |
| **switch** | Menu handling | Multi-way branching |
| **for** | Iterate students | Loop through collection |
| **while** | Input validation | Repeat until condition met |
| **TryParse** | `int.TryParse()` | Safe type conversion |

---

## Educational Value

This project is ideal for learning:
- ✅ Real-world application structure
- ✅ Practical problem-solving
- ✅ Data organization and management
- ✅ User input/output handling
- ✅ Data validation techniques
- ✅ Method design and reusability
- ✅ Scope and variable lifetime
- ✅ Interactive console applications

---

## System Requirements

- **.NET Version**: .NET 10 or higher
- **C# Version**: 14.0
- **IDE**: Visual Studio 2026 or later (or VS Code with C# extension)
- **Platform**: Windows, Linux, or macOS

---

## Features Highlight

 **Beautiful Console UI**
- Box drawing characters (╔═╗║╚╝)
- Color-coded output (Yellow, Green, Red, Cyan)
- Emoji indicators (✅ ❌ 📝 📚 🔍)

**Robust Validation**
- Duplicate prevention
- Range checking
- Type safety with TryParse

**Real-time Calculations**
- Instant total computation
- Automatic average calculation
- Dynamic grade assignment

---

## 💡 Enhancements for Advanced Learning

Potential improvements to explore:

1. **File I/O** - Save/load student data from files
2. **Collections** - Use `List<T>` instead of arrays
3. **LINQ** - Query student data
4. **Serialization** - JSON data format
5. **Exception Handling** - Try-catch blocks
6. **Database** - SQL Server integration
7. **GUI** - Windows Forms or WPF
8. **Unit Tests** - xUnit or NUnit

---

## Conclusion

This **Student Grade Management System** provides hands-on experience with all fundamental C# concepts in a practical, interactive application. It demonstrates how basic programming constructs combine to create a useful real-world system suitable for educational institutions to track student performance.

**Happy Learning!**
