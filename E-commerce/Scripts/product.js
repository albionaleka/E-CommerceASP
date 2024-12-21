import { products, fetchData, getMatching } from "../data/products.js";
import formatPrice from "./utils/money.js";
import { addToCart } from "../data/cart.js";
import search from "./utils/search.js";
import contact from "./utils/contact.js";

async function generateHtml() {
    await fetchData();

    let html = '';
    let recommended = '';

    let product;

    let url = new URL(window.location.href);
    let productId = url.searchParams.get('product');

    product = getMatching(productId);

    const category = product.type;

    const recommendedProducts = [];

    products.forEach(item => {
        if (item.type === category && item.id !== product.id) {
            recommendedProducts.push(item);
        }
    });

    html += `
        <div class="col-lg">
            <img src="${product.image}" class="img-fluid rounded" alt="${product.name}" data-product-id="${product.id}">
        </div>

        <div class="col-lg">
            <h1 class="heading orange-text">${product.name}</h1>

            <p class="justify lh-lg desc">${product.desc}</p>

            <div class="row align-items-center">
                <div class="col-5">
                    <p class="biggerText">Price: ${formatPrice(product.price)}€</p>
                </div>

                <div class="col-7">
                    <button class="blue-btn js-addProduct" data-product-id="${product.id}">
                        Add to cart
                    </button>
                </div>
            </div>
        
        </div>
    `;

    recommendedProducts.forEach(product => {
        recommended += `
            <div class="product-card card mb-3">
                <div class="row g-0">
                    <div class="col-md-4 d-flex justify-content-center align-items-center product-image">
                        <img src="${product.image}" class="img-fluid recommended-img" alt="${product.name}" data-product-id="${product.id}">
                    </div>

                    <div class="col-md-8">
                        <div class="card-body">
                            <h6 class="card-title">${product.name}</h6>
                            <p class="price">
                                Price:
                                <strong>${formatPrice(product.price)}€</strong>
                            </p>
                            
                            <button class="orange-btn js-addProduct" data-product-id="${product.id}">
                                Add to cart
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        `;
    });

    document.title = product.name;

    search();

    $(".product-info").html(html);

    $(".recommended-products").html(recommended);

    $(".js-addProduct").click(function() {
        const { productId } = this.dataset;

        addToCart(productId);

        $(".added").show();

        setTimeout(() => {
            $(".added").hide();
        }, 3000);
    });

    $(".product-card img").click(function() {
        const { productId } = this.dataset;

        window.location.href = `product.html?product=${productId}`;
    });

    contact();
}

generateHtml();