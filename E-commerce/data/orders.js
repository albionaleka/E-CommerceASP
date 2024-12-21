import { cart, notify } from "./cart.js";

export let orders = [];

loadFromStorage();

export function loadFromStorage() {
    orders = JSON.parse(localStorage.getItem('orders')) || [];
}

export function saveLocally() {
    localStorage.setItem('orders', JSON.stringify(orders));
}

export function order() {
    let id = uuid.v4();
    const time = dayjs().format('DD/MM/YYYY');

    orders.unshift({
        "id": id,
        "contents": cart,
        "time": time,
    });

    localStorage.removeItem('cart');

    notify("Order has been placed.");

    saveLocally();
}