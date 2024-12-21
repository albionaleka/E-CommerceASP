import { getMatching } from "./products.js";

export let cart;

loadFromStorage();

export function loadFromStorage() {
    cart = JSON.parse(localStorage.getItem('cart')) || [];
}

export function saveLocally() {
    localStorage.setItem("cart", JSON.stringify(cart));
}

export function addToCart(productId) {
    let matchingItem;

    cart.forEach(item => {
        if (productId === item.productId) {
            matchingItem = item;
        }
    });

    if (matchingItem) {
        matchingItem.quantity += 1;
    } else {
        cart.push({
            "productId": productId,
            "quantity": 1
        });
    }

    let productName = getMatching(productId).name;

    notify(`"${productName}" has been added to cart!`)

    saveLocally();
}

export function deleteFromCart(productId) {
    let updated = [];

    cart.forEach(item => {
        if (item.productId !== productId) {
            updated.push(item);
        }
    });

    cart = updated;

    let productName = getMatching(productId).name;

    notify(`"${productName}" has been deleted from your cart!`)

    saveLocally();
}

export function updateQuantity(productId, quantity) {
    let match;

    cart.forEach(item => {
        if (productId === item.productId) {
            match = item;
        }
    });

    match.quantity = quantity;

    saveLocally();
}

export function notify(message) {
    if (Notification.permission === "granted") {
        const notification = new Notification(message);
    } else if (Notification.permission !== "denied") {
        Notification.requestPermission().then((permission) => {
            if (permission === "granted") {
                const notification = new Notification(message);
            }
        });
    }
}

export function updateDeliveryOption(deliveryOptionId) {
    cart.deliveryOption = deliveryOptionId;
    
    saveLocally();
}