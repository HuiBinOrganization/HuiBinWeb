// Equal Height Columns
$(document).ready(function() {
    var lth = $(".doctab").height()
        rth = $(".week").height();
	if(lth > rth ) {
		$(".week").height(lth);
	}
	else {
		$(".doctab").height(rth);
	}
});
// Slider
$(document).ready(function(){	
	var sudoSlider = $("#slider").sudoSlider({ 
		speed:500
	});
});
// browser
$(document).ready(function() {
    $(".browser-close").click(function() {
      $(".browser").hide()
    });
});