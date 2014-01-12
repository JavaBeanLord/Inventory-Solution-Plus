<!DOCTYPE html>
<html>

<head>
<script type="text/javascript" src="script.js"></script>
<link rel="stylesheet" type="text/css" href="mystyles.css" media="screen" />
<title>Inventory Manager</title>
</head>

<body>
<h1>Inventory Manager</h1>

<div id="inventoryTable">
<?php
$con=mysqli_connect("localhost","Ethan","password","inventory");
// Check connection
if (mysqli_connect_errno())
  {
  	echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }

$result = mysqli_query($con,"SELECT * FROM computers");

echo "<table border='1' align='center'>
<tr>
<th>ID</th>
<th>Name</th>
<th>Brand</th>
<th>OS</th>
<th>Quantity</th>
</tr>";

while($row = mysqli_fetch_array($result))
  {
  	echo "<tr>";
  	echo "<td>" . $row['CompID'] . "</td>";
  	echo "<td>" . $row['CompName'] . "</td>";
  	echo "<td>" . $row['Brand'] . "</td>";
  	echo "<td>" . $row['OperatingSys'] . "</td>";
  	echo "<td>" . $row['Quantity'] . "</td>";
  	echo "</tr>";
  }
echo "</table>";

mysqli_close($con);
?>
</div>

<div class="buttonClass">
<button onclick="myFunction()">Try it</button>
</div>

</body>


</html>