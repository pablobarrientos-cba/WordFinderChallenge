# WordFinder Challenge – C# Implementation

This project is a solution to a technical interview challenge: 
finding the top 10 most repeated words from a large word stream within a 64x64 character matrix. 
The solution is built with performance, maintainability, and clean code principles in mind.

## Technologies Used

-  C# (.NET 8)
-  xUnit for unit testing
-  FluentAssertions for expressive test assertions
-  SOLID principles & clean architecture


## Problem Summary

> Given a character matrix (up to 64x64) and a stream of words, build a class 
that searches the matrix for those words.
Words may appear **horizontally (left to right)** or **vertically (top to bottom)**. 
The output must be the **top 10 most repeated words found**.

## Solution Overview

- **Class:** `WordFinder`  
- **Interface:** `IWordFinder` for extensibility  
- **Extension Methods** for matrix validation (e.g., size, null, uniformity)  
- **LINQ** and **StringComparison.OrdinalIgnoreCase** for clean and efficient search  
- **HashSet** to deduplicate the word stream  
- **Unit Tests** with clear behavior-driven test cases using `FluentAssertions`

---

## Test Coverage

 - Horizontal and vertical word matches  
 - Case-insensitive matching  
 - Matrix validation errors  
 - Empty and unmatched word streams  
 - Top 10 most repeated words  



## Run the Project

```
dotnet restore
dotnet build
dotnet test
```

---

## Future Improvements

- Add diagonal and reverse search strategies via strategy pattern.
- Introduce parallel processing for massive word streams with `Parallel.ForEach` .

---

## Author

**Pablo Barrientos** – Senior Software Engineer | .NET & .NET Core Developer
https://www.linkedin.com/in/pablobarrientos

