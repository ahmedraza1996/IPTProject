$(document).on('ready', function(){

	//------- Google Maps ---------//
		  
	// Creating a LatLng object containing the coordinate for the center of the map
	var latlng = new google.maps.LatLng(53.385846,-1.471385);
	  
	// Creating an object literal containing the properties we want to pass to the map  
	var options = {  
		zoom: 15, // This number can be set to define the initial zoom level of the map
		center: latlng,
		mapTypeId: google.maps.MapTypeId.ROADMAP // This value can be set to define the map type ROADMAP/SATELLITE/HYBRID/TERRAIN
	};  
	// Calling the constructor, thereby initializing the map  
	var map = new google.maps.Map(document.getElementById('map_div'), options);  
	
	// Define Marker properties
	var image = new google.maps.MarkerImage('images/marker1.png',
		new google.maps.Size(100, 100),
		new google.maps.Point(0,0),
		new google.maps.Point(18, 42)
	);

	// Define Marker properties
	var image2 = new google.maps.MarkerImage('images/marker2.png',
		new google.maps.Size(100, 100),
		new google.maps.Point(0,0),
		new google.maps.Point(0, 42)
	);

	// Define Marker properties
	var image3 = new google.maps.MarkerImage('images/marker3.png',
		new google.maps.Size(100, 100),
		new google.maps.Point(0,0),
		new google.maps.Point(0, 42)
	);

	// Define Marker properties
	var image4 = new google.maps.MarkerImage('images/marker4.png',
		new google.maps.Size(100, 100),
		new google.maps.Point(0,0),
		new google.maps.Point(0, 42)
	);

	// Define Marker properties
	var image5 = new google.maps.MarkerImage('images/marker2.png',
		new google.maps.Size(100, 100),
		new google.maps.Point(0,0),
		new google.maps.Point(0, 42)
	);

	// Define Marker properties
	var image6 = new google.maps.MarkerImage('images/marker1.png',
		new google.maps.Size(100, 100),
		new google.maps.Point(0,0),
		new google.maps.Point(0, 42)
	);

	// Define Marker properties
	var image7 = new google.maps.MarkerImage('images/marker4.png',
		new google.maps.Size(100, 100),
		new google.maps.Point(0,0),
		new google.maps.Point(18, 42)
	);

	// Define Marker properties
	var image8 = new google.maps.MarkerImage('images/marker3.png',
		new google.maps.Size(100, 100),
		new google.maps.Point(0,0),
		new google.maps.Point(18, 42)
	);

	
	// Add Marker
	var marker1 = new google.maps.Marker({
		position: new google.maps.LatLng(53.385846,-1.471385), 
		map: map,		
		icon: image // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
	});	

	// Add Marker
	var marker2 = new google.maps.Marker({
		position: new google.maps.LatLng(53.389000,-1.473000), 
		map: map,		
		icon: image2 // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
	});

	// Add Marker
	var marker3 = new google.maps.Marker({
		position: new google.maps.LatLng(53.381000,-1.471000), 
		map: map,		
		icon: image3 // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
	});

	// Add Marker
	var marker4 = new google.maps.Marker({
		position: new google.maps.LatLng(53.391000,-1.480000), 
		map: map,		
		icon: image4 // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
	});

	// Add Marker
	var marker5 = new google.maps.Marker({
		position: new google.maps.LatLng(53.385000,-1.490000), 
		map: map,		
		icon: image5 // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
	});

	// Add Marker
	var marker6 = new google.maps.Marker({
		position: new google.maps.LatLng(53.385000,-1.500000), 
		map: map,		
		icon: image6 // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
	});

	// Add Marker
	var marker7 = new google.maps.Marker({
		position: new google.maps.LatLng(53.385000,-1.450000), 
		map: map,		
		icon: image7 // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
	});

	// Add Marker
	var marker8 = new google.maps.Marker({
		position: new google.maps.LatLng(53.384000,-1.460000), 
		map: map,		
		icon: image8 // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
	});
	
	// Add listener for a click on the pin
	google.maps.event.addListener(marker1, 'click', function() {  
		infowindow1.open(map, marker1);  
		$('body .infowindow').parent().parent().parent().parent().parent().parent().addClass('custom-tooltip')
	});

	// Add listener for a click on the pin
	google.maps.event.addListener(marker2, 'click', function() {  
		infowindow2.open(map, marker2);  
		$('body .infowindow').parent().parent().parent().parent().parent().parent().addClass('custom-tooltip')
	});

	// Add listener for a click on the pin
	google.maps.event.addListener(marker3, 'click', function() {  
		infowindow3.open(map, marker3);  
		$('body .infowindow').parent().parent().parent().parent().parent().parent().addClass('custom-tooltip')
	});

	// Add listener for a click on the pin
	google.maps.event.addListener(marker4, 'click', function() {  
		infowindow4.open(map, marker4);  
		$('body .infowindow').parent().parent().parent().parent().parent().parent().addClass('custom-tooltip')
	});

	// Add listener for a click on the pin
	google.maps.event.addListener(marker5, 'click', function() {  
		infowindow5.open(map, marker5);  
		$('body .infowindow').parent().parent().parent().parent().parent().parent().addClass('custom-tooltip')
	});

	// Add listener for a click on the pin
	google.maps.event.addListener(marker6, 'click', function() {  
		infowindow6.open(map, marker6);  
		$('body .infowindow').parent().parent().parent().parent().parent().parent().addClass('custom-tooltip')
	});

	// Add listener for a click on the pin
	google.maps.event.addListener(marker7, 'click', function() {  
		infowindow7.open(map, marker7);  
		$('body .infowindow').parent().parent().parent().parent().parent().parent().addClass('custom-tooltip')
	});

	// Add listener for a click on the pin
	google.maps.event.addListener(marker8, 'click', function() {  
		infowindow8.open(map, marker8);  
		$('body .infowindow').parent().parent().parent().parent().parent().parent().addClass('custom-tooltip')
	});
		
	// Add information window
	var infowindow1 = new google.maps.InfoWindow({  
		content:  createInfo('<div class="map-can"><div class="map-candimg"><img src="images/resource/err1.jpg" alt="" /></div><div class="emply-resume-info"> <h3><a href="#" title="">Ali TUFAN</a></h3> <span><i>UX / UI Designer</i></span> <p>Istanbul / Turkey</p> </div></div>')
	}); 

	// Add information window
	var infowindow2 = new google.maps.InfoWindow({  
		content:  createInfo('<div class="map-can"><div class="map-candimg"><img src="images/resource/err2.jpg" alt="" /></div><div class="emply-resume-info"> <h3><a href="#" title="">Ali TUFAN</a></h3> <span><i>UX / UI Designer</i></span> <p>Istanbul / Turkey</p> </div></div>')
	}); 

	// Add information window
	var infowindow3 = new google.maps.InfoWindow({  
		content:  createInfo('<div class="map-can"><div class="map-candimg"><img src="images/resource/err3.jpg" alt="" /></div><div class="emply-resume-info"> <h3><a href="#" title="">Ali TUFAN</a></h3> <span><i>UX / UI Designer</i></span> <p>Istanbul / Turkey</p> </div></div>')
	}); 

	// Add information window
	var infowindow4 = new google.maps.InfoWindow({  
		content:  createInfo('<div class="map-can"><div class="map-candimg"><img src="images/resource/err4.jpg" alt="" /></div><div class="emply-resume-info"> <h3><a href="#" title="">Ali TUFAN</a></h3> <span><i>UX / UI Designer</i></span> <p>Istanbul / Turkey</p> </div></div>')
	}); 

	// Add information window
	var infowindow5 = new google.maps.InfoWindow({  
		content:  createInfo('<div class="map-can"><div class="map-candimg"><img src="images/resource/err5.jpg" alt="" /></div><div class="emply-resume-info"> <h3><a href="#" title="">Ali TUFAN</a></h3> <span><i>UX / UI Designer</i></span> <p>Istanbul / Turkey</p> </div></div>')
	}); 

	// Add information window
	var infowindow6 = new google.maps.InfoWindow({  
		content:  createInfo('<div class="map-can"><div class="map-candimg"><img src="images/resource/err6.jpg" alt="" /></div><div class="emply-resume-info"> <h3><a href="#" title="">Ali TUFAN</a></h3> <span><i>UX / UI Designer</i></span> <p>Istanbul / Turkey</p> </div></div>')
	});

	// Add information window
	var infowindow7 = new google.maps.InfoWindow({  
		content:  createInfo('<div class="map-can"><div class="map-candimg"><img src="images/resource/err7.jpg" alt="" /></div><div class="emply-resume-info"> <h3><a href="#" title="">Ali TUFAN</a></h3> <span><i>UX / UI Designer</i></span> <p>Istanbul / Turkey</p> </div></div>')
	});

	// Add information window
	var infowindow8 = new google.maps.InfoWindow({  
		content:  createInfo('<div class="map-can"><div class="map-candimg"><img src="images/resource/err8.jpg" alt="" /></div><div class="emply-resume-info"> <h3><a href="#" title="">Ali TUFAN</a></h3> <span><i>UX / UI Designer</i></span> <p>Istanbul / Turkey</p> </div></div>')
	});
	
	// Create information window
	function createInfo(title, content) {
		return '<div class="infowindow"><span>'+ title +'</span>'+content+'</div>';
	} 

});

