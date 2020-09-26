$(document).ready(function() {
    //Load all available products
    
        $.ajax({
            url: '/api/FeedBack/GetAllFeedBacks',
            method: 'GET',
            success: function(data) {
                $('#tblBody').empty();
                $.each(data, function(index, value) {
                    var row = $('<tr><td > ' + value.PostId + '</td><td>'
                        + value.CommentContent + '</td><td>'
                        + value.UserName + '</td><td>'
                        + value.CommentTime + '</td><td>'
                        + value.LikeCount + '</td><td>'
                        + value.DisLikeCount + '</td></tr>');
                    $('#tblData').append(row);
                });
            }
        });
    });