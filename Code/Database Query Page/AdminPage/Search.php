<?php
ob_start();
include('session.php');
session_start();

				  if(isset($_POST['submit'])){
					  //echo "<p>Submitted</p>";
					  //do  something here in code
					  if(isset($_GET['go'])){
						  //echo "<p>Go</p>";  

						  $sql = createQuery();
						  try
						  {
							  $result = mysqli_query($db,$sql);
							  if($result->num_rows == 0)
							  {
								  $error = "No data matches the criteria";
							  }
							  else
							  {
                                  $rows = array();
                                  while($row=mysqli_fetch_array($result,MYSQLI_ASSOC)){
                                      $rows[] = $row;
                                  }
                                 // $_SESSION['badges'] = $badge_ids;
								  $_SESSION['result'] = $rows;
								  header("location: Search_submit.php"); /* Redirect browser */
								  exit();	
							  }
						  }
						  catch(Exception $e) {
							  echo 'Caught exception: ',  $e->getMessage(), "\n";
						  }

					  }
					  else {
						  //echo  "<p>Please enter a search criteria</p>";
					  }
				  }			 
                  function createQuery()
                  {
                      $sort=$_POST['sort'];
                      $order=$_POST['order'];
                      //$pp=$_POST['pp'];
                      $photo=$_POST['hasphoto'];
                      $video=$_POST['hasvideo'];
                      $tattoos=$_POST['notattoos'];
                      $piercings=$_POST['nopiercings'];
                      $firstName=$_POST['FirstName'];
                      $lastName=$_POST['LastName'];
                      $gender=$_POST['gender'];
                      $email=$_POST['emailsearch'];
                      $phone=$_POST['phone'];
                      $age1=$_POST['age1'];
                      $age2=$_POST['age2'];
                      $heightqual=$_POST['heightqual'];
                      $heightfoot=$_POST['heightfoot'];
                      $heightinch=$_POST['heightinch'];
                      $weightqual=$_POST['weightqual'];
                      $weight=$_POST['weight'];
                      $hairqual=$_POST['hairqual'];
                      $hair=$_POST['hair'];
                      $eyequal=$_POST['eyequal'];
                      $eyes=$_POST['eyes'];
                      $chest1=$_POST['chest1'];
                      $chest2=$_POST['chest2'];
                      $waist1=$_POST['waist1'];
                      $waist2=$_POST['waist2'];
                      $hips1=$_POST['hips1'];
                      $hips2=$_POST['hips2'];
                      $shirt=$_POST['shirt'];
                      $pant=$_POST['pant'];
                      $dress=$_POST['dress'];
                      $shoesize=$_POST['shoesize'];
                      $ethnicity=$_POST['ethnicity'];
                      $altethnicity=$_POST['altethnicity'];
                      $language=$_POST['language'];
                      $altlanguage=$_POST['altlanguage'];
                      $sector=$_POST['sector'];
                      $altsector=$_POST['altsector'];
                      $location=$_POST['location'];
                      $altlocation=$_POST['altlocation'];
                      $travel=$_POST['willtravel'];
                      $zipdistance=$_POST['zipdistance'];
                      $zipcode=$_POST['zipcode'];

                      $counter = 0;
                      $sql = "SELECT * FROM registered_staff WHERE ";
                      if ($firstName != "")
                      {
                          $sql .= "firstName = '$firstName' ";
                          $counter++;
                      }
                      if ($lastName != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "lastName = '$lastName' ";
                          $counter++;
                      }
                      if ($gender != "0")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "gender = '$gender' ";
                          $counter++;
                      }
                      if ($email != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "email = '$email' ";
                          $counter++;
                      }
                      if($phone != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "phone = '$phone' ";
                          $counter++;
                      }
                      if($photo == 1)
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "imageName != 'null' ";
                          $counter++;                          
                      }
                      if($video == 1)
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "videoName != 'null' ";
                          $counter++;
                          
                      }
                      if($tattoos == 1)
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "tattoos = 'no' ";
                          $counter++;
                          
                      }
                      if($piercings == 1)
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "piercings = 'no' ";
                          $counter++;
                      }
                      // if($age1 != "")
                      //{
                      //}
                      //if ($age2 != "")
                      //{                      		   
                      //}
                      if ($heightfoot != "'")
                      {
                              if ($counter != 0)
                              {
                                  $sql .= " and ";
                              }                             
                              if ($heightinch != '"')
                              {
                                  $d = $heightfoot . "." . $heightinch; 
                              }
                              else
                              {
                                  $d = $heightfoot; 

                              }
                              $sql .= "height " . $heightqual . floatval($d);
                              if ($heightqual == "<=")
                              {
                                  $sql .= " and height > 0.0";
                              }
                                      
							  $counter++;
                      }
                      if ($weight != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }  
                          
                          $sql .= "weight " . $weightqual . floatval($weight);
                          
                          if ($weightqual == "<=")
                          {
                              $sql .= " and weight > 0.0";
                          }
                          
                          $counter++;
                      }
                      if ($hair != "SELECT")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "hairColor " . $hairqual . " '$hair' ";
                          if ($hairqual == "!=")
                          {
                              $sql .= " and hairColor != 'null'";

                          }
                          $counter++;
                      }
                      if ($eyes != "SELECT")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "eyeColor " . $eyequal . " '$eyes' ";
                          if ($eyequal == "!=")
                          {
                              $sql .= " and eyeColor != 'null'";

                          }
                          $counter++;
                      }
                      if ($chest1 != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "chestSize >= " . $chest1;
                          $counter++;
                      }
                      if ($chest2 != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "chestSize <= " . $chest2 . " and chestSize > 0.0";
                          $counter++;
                      }
                      if ($waist1 != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "waistSize >= " . $waist1;
                          $counter++;
                      }
                      if ($waist2 != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "waistSize <= " . $waist2 . " and waistSize > 0.0";
                          $counter++;
                      }
                      if ($hips1 != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "hipSize >= " . $hips1;
                          $counter++;
                      }
                      if ($hips2 != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "hipSize <= " . $hips2 . " and hipSize > 0.0";
                          $counter++;
                      }
                      if ($shirt != "SELECT")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "shirtSize = '$shirt' ";
                          $counter++;
                      }
                      if ($pant != "SELECT")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "pantSize = '$pant' ";
                          $counter++;
                      }
                      if ($dress != "SELECT")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "dressSize = '$dress' ";
                          $counter++;
                      }
                      if ($shoesize != "SELECT")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "shoesize = '$shoesize' ";
                          $counter++;
                      }
                      if ($ethnicity != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          if ($ethnicity == "on" && $altethnicity != "")
                          {
                              $sql .= "ethnicity = '$altethnicity' ";                              
                          }else
                          {
                              $sql .= "ethnicity = '$ethnicity' ";                              

                          }
                                               
                          $counter++;
                      }
                      if ($language != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          if ($language == "on" && $altlanguage != "")
                          {
                              $sql .= "nativeLanguage = '$altlanguage' or secondLanguage = '$altlanguage' or thirdLanguage = '$altlanguage' ";
                          }else
                          {
                              $sql .= "nativeLanguage = '$language' or secondLanguage = '$language' or thirdLanguage = '$language' ";

                          }

                          $counter++;
                      }
                      if($sector != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          if ($sector == "on" && $altsector != "")
                          {
                              $sql .= "staffType = '$altsector' ";
                          }else
                          {
                              $sql .= "staffType = '$sector' ";

                          }

                          $counter++;
                      }
                      if($location != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          if ($location == "on" && $altlocation != "")
                          {
                              $sql .= "state = '$altlocation' ";
                          }else
                          {
                              $sql .= "state = '$location' ";

                          }

                          $counter++;
                      }
                      if ($travel != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }

                          $sql .= "travel = '$travel' ";
                          $counter++;
                      }
                      if ($zipcode != "")
                      {
                          if ($counter != 0)
                          {
                              $sql .= " and ";
                          }
                          $sql .= "zipcode = '$zipcode' ";
                          $counter++;
                      }
                      if ($counter == 0)
                      {
                          $sql = str_replace("WHERE", " ", $sql);
                      }

                      $sql .= " ORDER BY " . $sort . " " . $order;

                      return $sql;
                  }
			
		
		
?>
<html lang="en-US">
<head>
	<title>Welcome </title>
	<style type="text/css">
        body {			
            font-size: 14px;
			}
    </style>
</head>

<body bgcolor="#FFFFFF">
	<h1>
		Welcome <?php echo $login_session; ?>
	</h1>
	<h2>
		<a href="logout.php">Sign Out</a>
	</h2>
	<p class="big">
		Please select some parameters for your Search, then click "Submit".
		<br />
		You can reset the form by clicking "Reset".
	</p>

	<div style="margin:30px" >
        <form action="Search.php?go" method="post" name="searchCriteria">
            <div style="font-size:22px; color:#cc0000; margin-top:10px">
                <?php echo $error; ?>
            </div>
            <table border="0" align="center">
				<tbody>
					<tr>
						<td colspan="2">&nbsp;</td>
					</tr>
				</tbody>
			</table>
           	<table cellpadding="0" cellspacing="5" border="0" width="950" class="search">
                <tbody>
                    <tr>
                        <td width="230" height="29" class="formtitle">
                            Sort By &nbsp;<select name="sort">
                                <option selected="selected" value="firstName">First Name</option>
                                <option value="lastName">Last Name</option>
                                <option value="phone">Phone</option>                              
                            </select>
                        </td>
                        <td class="formtitle lb" width="230">
                            Order &nbsp;<select name="order">
                                <option selected="selected" value="ASC">Ascending</option>
                                <option value="DESC">Descending</option>
                            </select>
                        </td>
                        <!--<td class="formtitle lb"  >
                            Contractors per page &nbsp;<select name="pp" onchange="doSubmit('0')">
                                <option selected="selected" value="5">5</option>
                                <option value="10">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="100">100</option>
                                <option value="250">250</option>
                            </select>
                        </td>-->
                    </tr>
                    <tr>
                        <td colspan="2" class="formtitle" width="400">
							First Name &nbsp;&nbsp;<input type="text" name="FirstName" class="formfield" value="">&nbsp;&nbsp;
                            Last Name &nbsp;&nbsp;<input type="text" name="LastName" class="formfield" value="">
						</td>                    
                        <td class="formoption lb">	
							<span class="formtitle">Gender</span>&nbsp;
							<input type="radio" name="gender" value="0" checked="checked">Either
							<input type="radio" name="gender" value="Male" >Male
							<input type="radio" name="gender" value="Female" >Female
						</td>
                    </tr>
                    <tr>
                        <td colspan="2" class="formtitle" width="400">Email&nbsp;&nbsp;
							<input type="text" name="emailsearch" class="formfield" value="">
						</td>
                        <td class="formoption lb">
							<input type="checkbox" name="hasphoto" value="1"> &nbsp;
							<span class="formtitle">Has Photo</span>&nbsp;&nbsp;&nbsp;&nbsp;
							<input type="checkbox" name="hasvideo" value="1"> &nbsp;
							<span class="formtitle">Has Video</span>
						</td>
		            </tr>
                    <tr>
                        <td colspan="3" class="formtitle" width="400">Phone &nbsp;
							<input type="text" name="phone" class="formfield" value="">
						</td>
                    </tr>
					<tr>
                        <td class="formtitle" colspan="3">
                            <!--Age&nbsp;&nbsp;&nbsp;<input name="age1" type="text" class="formfield-small" size="3" value="">&nbsp;to&nbsp;<input name="age2" class="formfield-small" type="text" size="3" value="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-->
                            Height <select name="heightqual">
                                <option selected="selected" value="<=">at most</option>
                                <option value=">=">at least</option>
                                <option value="=">equal to</option>
                            </select>&nbsp;<select name="heightfoot">
                                <option value="'">'</option>
                                <option value="4">4'</option>
                                <option value="5">5'</option>
                                <option value="6">6'</option>
                                <option value="7">7'</option>
                            </select>&nbsp;<select name="heightinch">
                                <option value="&quot;">"</option>
                                <option value="0">0"</option>
                                <option value="1">1"</option>
                                <option value="2">2"</option>
                                <option value="3">3"</option>
                                <option value="4">4"</option>
                                <option value="5">5"</option>
                                <option value="6">6"</option>
                                <option value="7">7"</option>
                                <option value="8">8"</option>
                                <option value="9">9"</option>
                                <option value="10">10"</option>
                                <option value="11">11"</option>
                            </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Weight&nbsp; <select name="weightqual">
                                <option selected="selected" value="<=">at most</option>
                                <option value=">=">at least</option>
                                <option value="=">equal to</option>
                            </select>&nbsp;<input name="weight" type="text" class="formfield-small" size="6" value=""> lbs
                        </td>
                    </tr>					
					<tr>
                        <td colspan="3" class="formtitle">
                            Hair Color <select name="hairqual">
                                <option selected="selected" value="=">is</option>
                                <option value="!=">is not</option>
                            </select>&nbsp;
							<select name="hair">
                                <option selected="selected" value="SELECT">SELECT</option>
                                <option value="Auburn">Auburn</option>
                                <option value="Bald">Bald</option>
                                <option value="Black">Black</option>
                                <option value="Blond">Blond</option>
                                <option value="Blue">Blue</option>
                                <option value="Brown">Brown</option>
                                <option value="Gray">Gray</option>
                                <option value="Green">Green</option>
                                <option value="Multicolor">Multicolor</option>
                                <option value="Purple">Purple</option>
                                <option value="Red">Red</option>
                                <option value="White">White</option>
                            </select>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Eye Color <select name="eyequal">
                                <option selected="selected" value="=">is</option>
                                <option value="!=">is not</option>
                            </select>&nbsp;
							<select name="eyes">
                                <option selected="selected" value="SELECT">SELECT</option>
                                <option value="Amber">Amber</option>
                                <option value="Blue">Blue</option>
                                <option value="Brown">Brown</option>
                                <option value="Gray">Gray</option>
                                <option value="Green">Green</option>
                                <option value="Hazel">Hazel</option>
                                <option value="Black">Black</option>
                            </select>
                            &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp;
                            <input type="checkbox" name="notattoos" value="1"> No Tattoos &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="checkbox" name="nopiercings" value="1"> No Piercings
                        </td>
                    </tr>
                    <tr>
						<td colspan="1" class="formtitle">
							<table>
                               <tbody>
                                  <tr>
									 <td class="formtitle">Chest</td>
                                     <td><input type="text" name="chest1" size="2" maxlength="2" class="ol"></td>
                                     <td> - </td>
                                     <td><input type="text" name="chest2" size="2" maxlength="2" class="ol"></td>
                                     <td>&nbsp;&nbsp;</td>
                                     <td class="formtitle">Waist</td>
                                     <td><input type="text" name="waist1" size="2" maxlength="2" class="ol"></td>
                                     <td> - </td>
                                     <td><input type="text" name="waist2" size="2" maxlength="2" class="ol"></td>
                                     <td>&nbsp;&nbsp;</td>
                                     <td class="formtitle">Hips</td>
                                     <td><input type="text" name="hips1" size="2" maxlength="2" class="ol"></td>
                                     <td> - </td>
                                     <td><input type="text" name="hips2" size="2" maxlength="2" class="ol"></td>
                                  </tr>
							 </tbody>
                          </table>                                              
                        </td>
                    </tr>
					<tr>
						<td colspan="4" class="formtitle">
							Shirt Size
							<select name="shirt">
								<option value="SELECT">SELECT</option>
								<option value="XS">XS</option>
								<option value="S">S</option>
								<option value="M">M</option>
								<option value="L">L</option>
								<option value="XL">XL</option>
								<option value="XXL">XXL</option>
								<option value="XXXL">XXXL</option>
								<option value="Other">Other</option>
							</select>
							Pant Size 
							<select name="pant">
								<option value="SELECT">SELECT</option>
								<option value="XS">XS</option>
								<option value="S">S</option>
								<option value="M">M</option>
								<option value="L">L</option>
								<option value="XL">XL</option>
								<option value="XXL">XXL</option>
								<option value="XXXL">XXXL</option>
								<option value="Other">Other</option>
							</select>
							Dress Size
							<select name="dress">
								<option value="SELECT">SELECT</option>
								<option value="XS">XS</option>
								<option value="S">S</option>
								<option value="M">M</option>
								<option value="L">L</option>
								<option value="XL">XL</option>
							    <option value="XXL">XXL</option>
								<option value="XXXL">XXXL</option>
							    <option value="Other">Other</option>
							</select>
							Shoe Size
							<select name="shoesize">
								<option value="SELECT">SELECT</option>
								<option value="4">4</option>
								<option value="4.5">4.5</option>
								<option value="5">5</option>
								<option value="5.5">5.5</option>
								<option value="6">6</option>
								<option value="6.5">6.5</option>
								<option value="7">7</option>
								<option value="7.5">7.5</option>
								<option value="8">8</option>
								<option value="8.5">8.5</option>
								<option value="9">9</option>
								<option value="9.5">9.5</option>
								<option value="10">10</option>
								<option value="10.5">10.5</option>
								<option value="11">11</option>
								<option value="11.5">11.5</option>
								<option value="12">12</option>
								<option value="12.5">12.5</option>
								<option value="13">13</option>
								<option value="13.5">13.5</option>
								<option value="14">14</option>
							</select>
						</td>
					</tr>
                    <tr>
                        <td class="formtitle" colspan="3">
                            <div class="half">
                                Ethnicity
                                <table>
									<tbody>
										<tr>
											<td><input type="checkbox" name="ethnicity" value="Prefer not to Share">Prefer not to Share</td>
											<td><input type="checkbox" name="ethnicity" value="Hispanic">Hispanic</td>
											<td><input type="checkbox" name="ethnicity" value="Pacific Islander">Pacific Islander</td>
										</tr>
										<tr>
											<td><input type="checkbox" name="ethnicity" value="Caucasian">Caucasian</td>
											<td><input type="checkbox" name="ethnicity" value="Asian">Asian</td>
										</tr>
										<tr>
											<td><input type="checkbox" name="ethnicity" value="African American">African American</td>
											<td><input type="checkbox" name="ethnicity" value="Native American">Native American</td>
										</tr>
									</tbody>
								</table>
								<table>
									<tbody>
										<tr>
											<td><input type="checkbox" name="ethnicity" value="on" id="other_ethnicity" class="other">Other</td>
											<td><input type="text" name="altethnicity" size="30" maxlength="255" style="height:22px;" id="other_ethnicity_value" class="formfield otheroption"></td>
										</tr>
									</tbody>
								</table>
                            </div>

                            <div class="half">
                                Languages
                                <table>
									<tbody>
										<tr>
											<td><input type="checkbox" name="language" value="English">English</td>
											<td><input type="checkbox" name="language" value="Japanese">Japanese</td>
											<td><input type="checkbox" name="language" value="German">German</td>
										</tr>
										<tr>
											<td><input type="checkbox" name="language" value="Spanish">Spanish</td>
											<td><input type="checkbox" name="language" value="Chinese">Chinese</td>
											<td><input type="checkbox" name="language" value="Italian">Italian</td>
										</tr>
										<tr>
											<td><input type="checkbox" name="language" value="Korean">Korean</td>
											<td><input type="checkbox" name="language" value="French">French</td>
											<td><input type="checkbox" name="language" value="Farsi">Farsi</td>
										</tr>
									</tbody>
								</table>
								<table>
									<tbody>
										<tr>
											<td><input type="checkbox" name="language" value="on" id="other_language" class="other">Other</td>
											<td><input type="text" name="altlanguage" size="30" maxlength="255" style="height:22px;" id="other_language_value" class="formfield otheroption"></td>
										</tr>
									</tbody>
								</table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="formtitle" colspan="3">
                            Promotional Sectors
                            <table>
								<tbody>
									<tr>
										<td><input type="checkbox" name="sector" value="Brand Ambassador">Brand Ambassador</td>
										<td><input type="checkbox" name="sector" value="Dancer">Dancer</td>
										<td><input type="checkbox" name="sector" value="Field Marketing Manager">Field Marketing Manager</td>
										<td><input type="checkbox" name="sector" value="Model">Model</td>
									</tr>
									<tr>
										<td><input type="checkbox" name="sector" value="Flyer Distributor">Flyer Distributor</td>
										<td><input type="checkbox" name="sector" value="Production Assistant">Production Assistant</td>
										<td><input type="checkbox" name="sector" value="Sales Executive">Sales Executive</td>
										<td><input type="checkbox" name="sector" value="Waiter/Waitrees">Waiter/Waitrees</td>
									</tr>
									<tr>
										<td><input type="checkbox" name="sector" value="DJ">DJ</td>
										<td><input type="checkbox" name="sector" value="Catering Company">Catering Company</td>
										<td><input type="checkbox" name="sector" value="Live Band">Live Band</td>
										<td><input type="checkbox" name="sector" value="Senior Marketing Manager">Senior Marketing Manager</td>
									</tr>
									<tr>
										<td><input type="checkbox" name="sector" value="Bartender">Bartender</td>
										<td><input type="checkbox" name="sector" value="Photographer">Photographer</td>
										<td><input type="checkbox" name="sector" value="Electrician">Electrician</td>
										<td><input type="checkbox" name="sector" value="Graphic Designer">Graphic Designer</td>
									</tr>
									<tr>
										<td><input type="checkbox" name="sector" value="Sound Engineer">Sound Engineer</td>
									</tr>
								</tbody>
							</table>
							<table>
								<tbody>
									<tr>
										<td><input type="checkbox" name="sector" value="on" id="other_sector" class="other">Other</td>
										<td><input type="text" name="altsector" size="30" maxlength="255" style="height:22px;" id="other_sector_value" class="formfield otheroption"></td>
									</tr>
								</tbody>
							</table>
                        </td>
                    </tr>
                 </tbody>
            </table>		
			<table cellpadding="0" cellspacing="5" border="0" width="800">
				<tbody>
                    <tr class="formtitle">
                        <td>Locations: 
							<table>
								<tbody>
									<tr>
										<td><input type="checkbox" name="location" value="AL">Alabama</td>
										<td><input type="checkbox" name="location" value="AK">Alaska</td>
										<td><input type="checkbox" name="location" value="AZ">Arizona</td>
										<td><input type="checkbox" name="location" value="AR">Arkansas</td>
										<td><input type="checkbox" name="location" value="CA">California</td>
									</tr>
                                    <tr>
                                        <td><input type="checkbox" name="location" value="CO">Colorado</td>
                                        <td><input type="checkbox" name="location" value="CT">Connecticut</td>
                                        <td><input type="checkbox" name="location" value="DE">Delaware</td>
                                        <td><input type="checkbox" name="location" value="FL">Florida</td>
                                        <td><input type="checkbox" name="location" value="GA">Georgia</td>
                                    </tr>
                                    <tr>
                                        <td><input type="checkbox" name="location" value="HI">Hawaii</td>
                                        <td><input type="checkbox" name="location" value="ID">Idaho</td>
                                        <td><input type="checkbox" name="location" value="IL">Illinois</td>
                                        <td><input type="checkbox" name="location" value="IN">Indiana</td>
                                        <td><input type="checkbox" name="location" value="IA">Iowa</td>
                                    </tr>
                                    <tr>
                                        <td><input type="checkbox" name="location" value="KS">Kansas</td>
                                        <td><input type="checkbox" name="location" value="KY">Kentucky</td>
                                        <td><input type="checkbox" name="location" value="LA">Louisiana</td>
                                        <td><input type="checkbox" name="location" value="ME">Maine</td>
                                        <td><input type="checkbox" name="location" value="MD">Maryland</td>
                                    </tr>
                                    <tr>
                                        <td><input type="checkbox" name="location" value="MA">Massachusetts</td>
                                        <td><input type="checkbox" name="location" value="MI">Michigan</td>
                                        <td><input type="checkbox" name="location" value="MN">Minnesota</td>
                                        <td><input type="checkbox" name="location" value="MS">Mississippi</td>
                                        <td><input type="checkbox" name="location" value="MO">Missouri</td>
                                    </tr>
                                    <tr>
                                        <td><input type="checkbox" name="location" value="MT">Montana</td>
                                        <td><input type="checkbox" name="location" value="NE">Nebraska</td>
                                        <td><input type="checkbox" name="location" value="NV">Nevada</td>
                                        <td><input type="checkbox" name="location" value="NH">New Hampshire</td>
                                        <td><input type="checkbox" name="location" value="NJ">New Jersey</td>
                                    </tr>
                                    <tr>
                                        <td><input type="checkbox" name="location" value="NM">New Mexico</td>
                                        <td><input type="checkbox" name="location" value="NY">New York</td>
                                        <td><input type="checkbox" name="location" value="NC">North Carolina</td>
                                        <td><input type="checkbox" name="location" value="ND">North Dakota</td>
                                        <td><input type="checkbox" name="location" value="OH">Ohio</td>
                                    </tr>
                                    <tr>
                                        <td><input type="checkbox" name="location" value="OK">Oklahoma</td>
                                        <td><input type="checkbox" name="location" value="OR">Oregon</td>
                                        <td><input type="checkbox" name="location" value="PA">Pennsylvania</td>
                                        <td><input type="checkbox" name="location" value="RI">Rhode Island</td>
                                        <td><input type="checkbox" name="location" value="SC">South Carolina</td>
                                    </tr>
                                    <tr>
                                        <td><input type="checkbox" name="location" value="SD">South Dakota</td>
                                        <td><input type="checkbox" name="location" value="TN">Tennessee</td>
                                        <td><input type="checkbox" name="location" value="TX">Texas</td>
                                        <td><input type="checkbox" name="location" value="UT">Utah</td>
                                        <td><input type="checkbox" name="location" value="VT">Vermont</td>
                                    </tr>
                                    <tr>
                                        <td><input type="checkbox" name="location" value="VA">Virginia</td>
                                        <td><input type="checkbox" name="location" value="WA">Washington</td>
                                        <td><input type="checkbox" name="location" value="WV">West Virginia</td>
                                        <td><input type="checkbox" name="location" value="WI">Wisconsin</td>
                                        <td><input type="checkbox" name="location" value="WY">Wyoming</td>
                                    </tr>						
								</tbody>
							</table>
							<table>
								<tbody>
									<tr>
										<td><input type="checkbox" name="location" value="on" id="other_location" class="other">Other</td>
										<td><input type="text" name="altlocation" size="30" maxlength="255" style="height:22px;" id="other_location_value" class="formfield otheroption"></td>
									</tr>
								</tbody>
							</table>
						</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" class="formoption lb">
                            <!--<span class="formtitle">Within
								<input type="text" name="zipdistance" class="formfield-small" size="3" value="">miles of
								<input class="formfield-small" type="text" name="zipcode" size="6" value=""> ZIP
							</span>
                            &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;-->
                            <span class="formtitle">Will Travel</span> &nbsp;&nbsp;&nbsp;&nbsp;<input type="radio" name="willtravel" value="Yes">Yes <input type="radio" name="willtravel" value="No">No <input type="radio" name="willtravel" value="Maybe">Maybe
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                            
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="buttons">
                <input type="submit" name="submit" value="Submit">
                <button onclick="doReset(0)">Reset</button>
            </div>
        </form>

		
			
	</div>
</body>

</html>