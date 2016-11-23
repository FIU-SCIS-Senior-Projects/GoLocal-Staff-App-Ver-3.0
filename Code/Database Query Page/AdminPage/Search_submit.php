<?php

include('session.php');
session_start();

	$result = $_SESSION['result'];

	foreach($result as $row){
		$FirstName  =$row['firstName'];
		$LastName=$row['lastName'];
		$ID=$row['staffID'];
		//-display the result of the array
		echo "<ul>\n";
		echo "<li>" . "<a  href=\"search.php?id=$ID\">"  .$ID . " " .$FirstName . " " . $LastName .  "</a></li>\n";
		echo "</ul>";
	}
    echo count($result);
?>