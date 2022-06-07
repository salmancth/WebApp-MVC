
function GetPersonList() {
	$.get("/Ajax/GetPerson", null, function (data) {
		$("#ListOfPerson").html(data);
	});
	document.getElementById('messages').innerText = "All Avilable Person";
}

function FindPersonById() {
	var idOfPersonValue = document.getElementById('personIdValue').value;
	$.post("/Ajax/FindPersonById", { personId: idOfPersonValue },
		function (data) {
			$("#ListOfPerson").html(data);
	});

	document.getElementById('messages').innerText = "Search Result";
}


function RemovePersonById() {
	var idOfPersonValue = document.getElementById('personIdValue').value;
	$.post("/Ajax/DeletePerson", { personId: idOfPersonValue }, function (data) {
		
	})
		.done(function () {
			GetPersonList();
			document.getElementById('messages').innerHTML = "Successfully Deleted Person";
			
		})
		.fail(function () {
			document.getElementById('messages').innerHTML = "Sorry ;( Could not delete Person";
		});
}


