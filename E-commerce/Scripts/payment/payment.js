import { cart } from "../../data/cart.js";
import formatPrice from "../utils/money.js";
import { getMatching } from "../../data/products.js";
import taxCalculator from "../utils/tax.js";

export function generatePayment() {
    let html = '';
    let productInfo = '';

    let productsPrice = 0;

    cart.forEach(item => {
        let matchingItem = getMatching(item.productId);

        let price = item.quantity * matchingItem.price;
        productsPrice += price;

        productInfo += `
            <div class="container product-info">
                <p class="full-width">
                    <span>${matchingItem.name}</span>
                    <span class="biggerText blue-text">
                        ${item.quantity}<small>x</small>
                    </span>
                </p>
                
                <p class="full-width">
                    <span class="biggerText">${formatPrice(matchingItem.price)}€</span>
                </p>
            </div>
        `
    });

    let tax = taxCalculator(productsPrice);

    html += `
        <div class="card">
            <div class="card-body">
                <h3 class="card-title featured-heading">Cart Summary</h3>
                
                <p class="card-text">
                    ${productInfo}
                </p>

                <hr class="w-75 mx-auto">

                <div class="container">
                    <div class="total-payment row align-items-center">
                        <div class="col">
                            <p class="card-text text-start">
                                Total before tax:
                            </p>
                        </div>

                        <div class="col">
                            <p class="card-text biggerText text-end">
                                ${formatPrice(productsPrice - tax)}€
                            </p>
                        </div>
                    </div>

                    <div class="total-payment row">
                        <div class="col">
                            <p class="card-text">
                                Tax (18%):
                            </p>
                        </div>

                        <div class="col">
                            <p class="card-text biggerText text-end">
                                ${formatPrice(tax)}€
                            </p>
                        </div>
                    </div>

                    <div class="total-payment row">
                        <div class="col">
                            <p class="card-text">
                                Total:
                            </p>
                        </div>

                        <div class="col">
                            <p class="card-text biggerText text-end">
                                ${formatPrice(productsPrice)}€
                            </p>
                        </div>
                    </div>
                </div>

                <button class="checkout-button">Checkout</button>
            </div>
        </div>
    `;

    $(".payment").html(html);
}