function contact() {
    $(".contact-toggle").click(function() {
        $(".backdrop").fadeIn("slow");
        $(".contact-form").show();
    });

    $(".cancel-message").click(function() {
        $(".backdrop").hide();
        $(".contact-form").hide();
    });
}

export default contact;