// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

// Nav active links
$('.nav .nav-link').click(function () {
	$('.nav .nav-link').removeClass('active');
	$(this).addClass('active');
})

$(document).ready(function () {
	$('#table_id').DataTable();
});