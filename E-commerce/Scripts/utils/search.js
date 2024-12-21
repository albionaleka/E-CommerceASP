function search() {
    $("#search").click(function() {
        const search = $(".search-input").val();
        window.location.href = `products.html?search=${search}`;
    });
}

export default search;