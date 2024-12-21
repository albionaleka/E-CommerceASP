export let products = [];

export const fetchData = async () => {
    const request = await fetch(`http://localhost:3001/products`);
    products = await request.json();
}

export const getMatching = (id) => {
    return products.find(product => product.id === id);
}