
  $(document).ready(function(){
 $('#btnConvert').click(function() {
		 var name = $('#name').val();
            var value = $('#price').val();
            doAjax(name,value);
    });
	
	 var doAjax = function (name,value) {
            $.ajax({
                url: 'http://localhost:53647/api/transform', 
                type: 'POST',
                data:JSON.stringify( { "name": name, "value":value }),
				contentType: 'application/json',
                responseType:'application/json',
                dataType:'json',
                success: function (response) {
                if(response.Data.Status=="success")
				{
					$('#nameDiv').text(response.Data.ConvertedInfoValues.name);
					$('#priceDiv').text(response.Data.ConvertedInfoValues.value);
				}
				else
					$('#nameDiv').text(response.Data.Error);
                },
				error: function(response) { 
          $('#nameDiv').text(response.Data.Error);
        }
            });
        };
});
  