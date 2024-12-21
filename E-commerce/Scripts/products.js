import { addToCart } from "../data/cart.js";
import { products, fetchData } from "../data/products.js";
import formatPrice from "./utils/money.js";
import capitalize from "./utils/capitalize.js";
import contact from "./utils/contact.js";
import search from "./utils/search.js";

export let categories = ['clothing', 'accessories', 'appliances', 'electronics', 'cosmetics', 'personal care', 'furniture', 'home', 'toys', 'outdoors'];

async function generateHtml () {
    await fetchData();

    let html = '';
    let categoryPicker = '';

    const url = new URL(window.location.href);
    const category = url.searchParams.get('category');
    const search = url.searchParams.get('search');

    let filtered = products;

    if (category) {
        filtered = products.filter(product => {
            let matchingCategory = false;

            if (product.type.toLowerCase() === category) {
                matchingCategory = true;
            }

            return matchingCategory|| product.name.toLowerCase().includes(category.toLowerCase());
        });
    }

    if (search) {
        filtered = products.filter(product => {
            let matching = false;

            if (product.name.toLowerCase().includes(search.toLowerCase()) || product.type.toLowerCase().includes(search.toLowerCase())) {
                matching = true;
            }

            return matching;
        });
    }

    filtered.forEach(product => {
        html += `
            <div class="col-md-4 mb-3">
                <div class="card product-card h-100 d-flex flex-column">
                    <img src="${product.image}" loading="lazy" class="card-img-top card-img img-fluid product-image" alt="${product.name}" data-product-id="${product.id}">
                    
                    <div class="card-content flex-fill">
                        <h5 class="product-name">${product.name}</h5>

                        <p class="card-text biggerText">Price: ${formatPrice(product.price)}€</p>
                        <button class="blue-btn js-addProduct" data-product-id="${product.id}">
                            Add to cart
                        </button>
                    </div>
                </div>
            </div>
        `;
    });

    categories.forEach(category => {
        categoryPicker += `
            <li><a class="dropdown-item dropdown-category" data-category="${category}">${capitalize(category)}</a></li>
        `;
    });

    $('.products-cards').html(html);
    $('#category-picker').html(categoryPicker);

    $(".js-addProduct").click(function() {
        const { productId } = this.dataset;

        addToCart(productId);

        $(".added").show();

        setTimeout(() => {
            $(".added").hide();
        }, 3000);
    });

    $(".dropdown-category").click(function() {
        $(this).addClass('active');

        const { category } = this.dataset;
        window.location.href = `products.html?category=${category}`;
    });

    $(".product-card img").click(function() {
        const { productId } = this.dataset;

        window.location.href = `product.html?product=${productId}`;
    });
    
    contact();
}

search();

generateHtml();