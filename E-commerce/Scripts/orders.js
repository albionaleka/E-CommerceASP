import { orders } from '../data/orders.js';
import { fetchData, products } from '../data/products.js';
import { getMatching } from '../data/products.js';
import formatPrice from './utils/money.js';
import { addToCart } from '../data/cart.js';
import search from './utils/search.js';
import contact from './utils/contact.js';

async function generateHtml() {
    await fetchData();

    let html = '';

    if (orders.length > 0) {
        orders.forEach(order => {
            html += `
                <div class="container order">
                    <h4 class="orange-text">Order ID: ${order.id}</h4>
                    <p>Placed on: ${order.time}</p>
    
                    <div class="row row-cols-1 row-cols-md-3 g-4 content">${generateInfo(order)}</div>
                </div>
            `;
        });
    } else {
        html += `
            <h2 class="text-center featured-heading">You haven't placed any orders yet...</h2>

            <div class="container recommended">
                <h3 class="text-center orange-text" id="recommended-heading">You might like</h3>

                <div class="row row-cols-1 row-cols-md-3 g-4 featured-products-cards text-center justify-content-center">
                    ${generateRecommended()}
                </div>

                <div class="d-flex justify-content-center">
                    <a href="products.html" class="blue-btn" id="view-all">View All</a>
                </div>
            </div>
        `;
    }

    search();

    $(".orders").html(html);

    contact();

    $(".purchase-again, .js-addProduct").click(function() {
        const { productId } = this.dataset;

        addToCart(productId);

        $(".added").show();

        setTimeout(() => {
            $(".added").hide();
        }, 3000);
    });
}

function generateInfo(order) {
    let html = '';

    order.contents.forEach(product => {
        let matchingProduct = getMatching(product.productId);

        html += `
        <div class="col-md-4 mb-3">
            <div class="card featured-card h-100 d-flex flex-column">
                <img src="${matchingProduct.image}" class="card-img-top card-img img-fluid" alt="${matchingProduct.name}" data-product-id="${product.productId}">

                <div class="card-content flex-fill container">
                    <h5 class="card-title">${matchingProduct.name}</h5>
                    <p class="card-text">${formatPrice(matchingProduct.price)}€</p>
                    
                    <p class="card-text justify">
                        <small class="quantity blue-text">
                            Quantity: ${product.quantity}
                        </small>
                    </p>

                    <div class="container d-flex justify-content-end purchase">
                        <button class="orange-btn purchase-again" data-product-id=${product.productId}>Purchase again</button>
                    </div>
                </div>
            </div>
        </div>
        `;
    });

    return html;
}

function generateRecommended() {
    let html = '';

    let recommended = products.slice(10, 15);

    recommended.forEach(product => {
        html += `
            <div class="col-md-4 mb-3">
                <div class="card featured-card h-100 d-flex flex-column">
                    <img src="${product.image}" class="card-img-top card-img img-fluid" alt="${product.name}" data-product-id="${product.id}">

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

    return html;
}

generateHtml();