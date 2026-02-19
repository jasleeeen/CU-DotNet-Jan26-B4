-- List all Product Names along with their Category Names
select p.productname, c.categoryname from products p
inner join categories c on p.categoryid = c.categoryid;


-- Display every Order ID alongside the Company Name of the customer who placed it.
select o.orderid, c.companyname from orders o
inner join customers c on o.customerid = c.customerid;


-- Show all Product Names and the Company Name of their respective suppliers.
select p.productname, s.companyname as supplier from products p
inner join suppliers s on p.supplierid = s.supplierid;


-- List all Orders (ID and Date) and the First/Last Name of the employee who processed them.
select o.orderid, o.orderdate, e.firstname, e.lastname from orders o
inner join employees e on o.employeeid = e.employeeid;


-- Find all Orders shipped to "France," showing the Order ID and the Company Name of the Shipper (from the Shippers table).
select o.orderid, s.companyname as shippername from orders o
inner join shippers s on o.shipvia = s.shipperid
where o.shipcountry = 'france';


-- Show the Category Name and the total number of units in stock for that category.
select c.categoryname, sum(p.unitsinstock) as totalunitsinstock from products p
inner join categories c on p.categoryid = c.categoryid group by c.categoryname;


-- List the Company Name and the total amount of money (Price $\times$ Quantity) they have spent across all orders
select c.companyname, sum(od.unitprice * od.quantity) as totalspent from customers c
inner join orders o on c.customerid = o.customerid
inner join [order details] od on o.orderid = od.orderid group by c.companyname;


-- Display the Last Name of each employee and the total number of orders they have taken.
select e.lastname, count(o.orderid) as totalorders from employees e
inner join orders o on e.employeeid = o.employeeid group by e.lastname;


-- Find the total Freight charges paid to each Shipper company
select s.companyname, sum(o.freight) as totalfreight from shippers s
inner join orders o on s.shipperid = o.shipvia group by s.companyname;


-- List the top 5 Product Names based on total quantity sold
select top 5 p.productname, sum(od.quantity) as totalquantitysold from products p
inner join [order details] od on p.productid = od.productid
group by p.productname order by totalquantitysold desc;


-- List all Product Names whose UnitPrice is greater than the average price of all products
select productname, unitprice from products
where unitprice > ( select avg(unitprice) from products);


-- Use a Self-Join on the Employees table to show each employee's name and their manager's name
select e.firstname + ' ' + e.lastname as employeename, m.firstname + ' ' + m.lastname as managername from employees e
left join employees m on e.reportsto = m.employeeid;


-- Find all Customers (Company Name) who have never placed an order (Use NOT IN or NOT EXISTS).
select companyname from customers c where not exists (
select 1 from orders o where o.customerid = c.customerid);


-- Identify Order IDs where the total order value is higher than the average order value of the entire database
select o.orderid from orders o
inner join [order details] od on o.orderid = od.orderid
group by o.orderid
having sum(od.unitprice * od.quantity) >
       (
         select avg(ordertotal) from (
              select sum(unitprice * quantity) as ordertotal from [order details] group by orderid
         ) as ordertotals
       );


-- Select Product Names that have never been ordered after the year 1997
select distinct p.productname
from products p
where not exists (
    select 1 from [order details] od inner join orders o on od.orderid = o.orderid
    where od.productid = p.productid and year(o.orderdate) > 1997
);


-- List all Employees and the names of the Regions they cover (requires joining Employees, EmployeeTerritories, Territories, and Region).
select e.firstname + ' ' + e.lastname as employeename, r.regiondescription from employees e
inner join employeeterritories et on e.employeeid = et.employeeid
inner join territories t on et.territoryid = t.territoryid
inner join region r on t.regionid = r.regionid;


-- Find Customers and Suppliers who are located in the same city
select c.companyname as customer, s.companyname as supplier, c.city from customers c
inner join suppliers s on c.city = s.city;


-- List Customers who have purchased products from more than 3 different categories
select c.companyname from customers c
inner join orders o on c.customerid = o.customerid
inner join [order details] od on o.orderid = od.orderid
inner join products p on od.productid = p.productid
group by c.companyname having count(distinct p.categoryid) > 3;


-- Calculate the total revenue generated only by products that are currently Discontinued
select sum(od.unitprice * od.quantity) as totalrevenue from [order details] od
inner join products p on od.productid = p.productid
where p.discontinued = 1;


-- For each Category, list the most expensive product name and its price
select p.productname, p.unitprice, c.categoryname from products p
inner join categories c on p.categoryid = c.categoryid
where p.unitprice = (
    select max(unitprice) from products where categoryid = p.categoryid
);