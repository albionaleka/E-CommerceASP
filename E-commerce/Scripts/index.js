import { products, fetchData } from "../data/products.js";
import formatPrice from "./utils/money.js";
import { addToCart } from "../data/cart.js";
import { categories } from "./products.js";
import capitalize from "./utils/capitalize.js";
import contact from "./utils/contact.js";
import search from "./utils/search.js";

async function generateHtml () {
    await fetchData();

    let html = '';

    const featured = products.slice(0, 6);

    featured.forEach(product => {
        html += `
            <div class="col-md-4 mb-3">
                <div class="featured-card card h-100 d-flex flex-column">
                    <img src="${product.image}" loading="lazy" class="card-img-top card-img img-fluid" alt="${product.name}" data-product-id="${product.id}">

                    <div class="card-content flex-fill">
                        <h5 class="card-title">${product.name}</h5>
                        <p class="card-text">${formatPrice(product.price)}€</p>
                        <button class="blue-btn js-addProduct" data-product-id="${product.id}">
                            Add to cart
                        </button>
                    </div>
                </div>
            </div>
        `;
    });

    let categoriesHTML = '';

    categories.forEach(category => {
        categoriesHTML += `
            <button value="${category}" class="orange-btn js-category-button">${capitalize(category)}</button>
        `;
    })

    $('.featured-products-cards').html(html);

    $(".category-buttons").html(categoriesHTML);

    search();

    $(".js-addProduct").click(function() {
        const { productId } = this.dataset;

        addToCart(productId);

        $(".added").show();

        setTimeout(() => {
            $(".added").hide();
        }, 3000);
    });

    $(".js-category-button").click(function() {
        const category = this.value;
        window.location.href = `products.html?category=${category}`;
    });

    $(".featured-card img").click(function() {
        const { productId } = this.dataset;

        window.location.href = `product.html?product=${productId}`;
    });

    contact();
}

generateHtml();