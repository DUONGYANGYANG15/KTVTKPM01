SELECT u.UserName, r.Name AS Role
FROM AspNetUsers u
JOIN AspNetUserRoles ur ON u.Id = ur.UserId
JOIN AspNetRoles r ON ur.RoleId = r.Id
WHERE u.Email = '2224802010786@student.tdmu.edu.vn';

DELETE FROM AspNetUserRoles
WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = '2224802010786@student.tdmu.edu.vn')
  AND RoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Engineer');
    INSERT INTO AspNetRoles (Id, Name, NormalizedName)
VALUES (NEWID(), 'Customer', 'CUSTOMER');
INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES
  (
    (SELECT Id FROM AspNetUsers WHERE Email = 'ngocngoctaicm@gmail.com'),
    (SELECT Id FROM AspNetRoles WHERE Name = 'Customer')
  );
  SELECT * FROM AspNetRoles WHERE Name = 'Customer';