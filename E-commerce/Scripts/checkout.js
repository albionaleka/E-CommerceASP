import { cart } from "../data/cart.js";
import { getMatching } from "../data/products.js";
import formatPrice from "./utils/money.js";
import { products, fetchData } from "../data/products.js";
import { generatePayment } from "./payment/payment.js";
import { addToCart, updateQuantity, deleteFromCart } from "../data/cart.js";
import search from "./utils/search.js";
import contact from "./utils/contact.js";
import { order } from "../data/orders.js";

async function generateHtml() {
    await fetchData();

    let html = '';

    if (cart.length > 0) {
        cart.forEach(product => {
            let matchingProduct = getMatching(product.productId);
    
            html += `
                <div class="product-card card mb-3">
                    <div class="row g-0 h-100 d-flex flex-fill">
                        <div class="col-md-4 d-flex">
                            <img src="${matchingProduct.image}" class="img-fluid rounded-start" alt="${matchingProduct.name}"  data-product-id='${matchingProduct.id}'>
                        </div>
    
                        <div class="col-md-8">
                            <div class="card-body">
                                <h6 class="product-name">${matchingProduct.name}</h6>
                                <p class="card-text justify">Price: ${formatPrice(matchingProduct.price)}€</p>
                               
                                <div class="row">
                                    <div class="col-sm-10">
                                        <p class="card-text justify">
                                            <small class="updated-${matchingProduct.id} orange-text">
                                                Quantity: <span class="js-product-quantity-${matchingProduct.id} product-quantity">${product.quantity}</span>

                                                <button class="blue-btn update-quantity js-cart-item-${matchingProduct.id}" data-product-id="${matchingProduct.id}">Update</button>
                                            </small>

                                            <small class="updating updating-${matchingProduct.id}">
                                                Quantity:
                                                <input class="quantity-input js-quantity-${matchingProduct.id}" type="number">
                                                <button class="blue-btn save-quantity" data-product-id="${matchingProduct.id}">Save</button>
                                            </small>
                                        </p>
                                    </div>

                                    <div class="col-sm-2">
                                        <button class="btn delete-product" data-product-id="${matchingProduct.id}">
                                            <i class="bi bi-trash3-fill orange-text trash-icon"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            `;
        });

        generatePayment();
    } else {
        let recommendedProducts = '<h1 class="orange-text checkout-heading">Recommendations</h1>';

        const recommended = products.slice(7, 10); 

        html += `
            <h2 class="orange-text checkout-heading">Your cart is empty.</h2>
        `;

        recommended.forEach(product => {
            recommendedProducts += `
                <div class="card mb-3 recommended-card">
                    <div class="row g-0">
                        <div class="col-md-4 d-flex justify-content-center align-items-center product-image">
                            <img src="${product.image}" class="img-fluid rounded" alt="${product.name}" data-product-id='${product.id}'>
                        </div>
    
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title">${product.name}</h5>
                                <p class="card-text">
                                    Price:
                                    <span class="biggerText">${formatPrice(product.price)}€</span>
                                </p>

                                <p class="card-text">
                                    <small>${product.desc}</small>
                                </p>
                                
                                <button class="button js-addProduct" data-product-id="${product.id}">
                                    Add to cart
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            `;
        });

        $(".recommended").html(recommendedProducts);

        $(".js-addProduct").click(function() {
            const { productId } = this.dataset;

            addToCart(productId);

            generateHtml();
        });
    }

    $('.cart-contents').html(html);

    $(".updating").hide();

    $(".update-quantity").click(function() {
        const { productId } = this.dataset;

        $(`.updated-${productId}`).hide();
        $(`.updating-${productId}`).show();
    });

    $(".save-quantity").click(function () {
        const { productId } = this.dataset;

        const quantity = $(`.js-quantity-${productId}`).val();
        updateQuantity(productId, quantity);

        if (quantity > 0) {
            $(`.js-product-quantity-${productId}`).text(quantity);
        } else {
            deleteFromCart(productId);
        }

        generateHtml();

        $(`.updating-${productId}`).hide();
        $(`.updated-${productId}`).show();
    });

    $(".delete-product").click(function() {
        const { productId } = this.dataset;

        deleteFromCart(productId);

        generateHtml();

        $(".deleted").show();

        setTimeout(() => {
            $(".deleted").hide();
        }, 3000);
    });

    $(".product-card img").click(function() {
        const { productId } = this.dataset;

        window.location.href = `product.html?product=${productId}`;
    });

    $(".recommended-card img").click(function() {
        const { productId } = this.dataset;

        window.location.href = `product.html?product=${productId}`;
    });

    contact();

    search();

    $(".checkout-button").click(function() {
        order();
        
        window.location.href = 'orders.html';
    });
}

generateHtml();