<?php

include('session.php');
session_start();

	$result = $_SESSION['result'];

	foreach($result as $row){
		$FirstName  =$row['firstName'];
		$LastName=$row['lastName'];
        $Phone = $row['phone'];
        $Email = $row['email'];
		$ID=$row['staffID'];
		//-display the result of the array
        $Display = "<li>" . "<a  href=\"search.php?id=$ID\">" . " ID: " . $ID . "</a> ";
        if($FirstName != "" || $LastName != "")
        {
            $Display .= " \t *Name: " .$FirstName . " " . $LastName;
        }
        if ($Email != "")
        {
            $Display .= " \t *Email: " . $Email;
        }
          if ($Phone != "")
        {
            $Display .= " \t *Phone: " . $Phone;
        }
          $Display .=  "</li>\n";
		echo "<ul>\n";
		echo $Display;
		echo "</ul>";
	}
    echo count($result);
?>