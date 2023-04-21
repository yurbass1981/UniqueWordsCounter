-- 1. Найти сотрудника с максимальной заработной платой

-- ВАРИАНТ I (Вывод сотрудника без указания зарплаты).
SELECT TOP(1)[Name] 
FROM
	(SELECT [Name], MAX(Salary) AS Salary
	FROM Employee
	GROUP BY [Name]) AS EmployeesSalary	
ORDER BY Salary DESC;

-- ВАРИАНТ II (Вывод сотрудника с указанием зарплаты).
SELECT TOP(1) [Name], MAX(Salary) AS Salary
FROM Employee
GROUP BY [Name]
ORDER BY Salary DESC;		
 	


-- 2. Вывести одно число: максимальную длину цепочки руководителей по таблице сотрудников (вычислить глубину дерева).

SELECT COUNT(DISTINCT ChiefId) AS NumberOfManagers
FROM Employee; 


-- 3. Вывести отдел, с максимальной суммарной зарплатой сотрудников.

-- ВАРИАНТ I (Вывод отдела с указанием суммарной зарплаты сотрудников).
SELECT TOP(1) 
	d.Name, SUM(e.Salary) AS MaximumTotalSalary 
FROM Department d
JOIN Employee e ON e.DepartmentId = d.Id 
GROUP BY d.Name
ORDER BY MaximumTotalSalary DESC;

-- ВАРИАНТ II (Вывод отдела без указания суммарной зарплаты сотрудников).
SELECT TOP(1) [Name] 
FROM
	(SELECT 
		d.Name, SUM(e.Salary) AS MaximumTotalSalary
	FROM Department d
	JOIN Employee e ON e.DepartmentId = d.Id
	GROUP BY d.Name) AS EmployeesSalary	
ORDER BY MaximumTotalSalary DESC;


-- 4. Найти сотрудника, чье имя начинается на «Р» и заканчивается на «н».
SELECT [Name] 
FROM Employee
WHERE [Name] LIKE 'Р%н';

