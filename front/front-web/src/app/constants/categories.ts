export const CATEGORIES = [
    { id: 0, name: '📱 Elektronika' },
    { id: 1, name: '🚗 Vozila' },
    { id: 2, name: '🏠 Nekretnine' },
    { id: 3, name: '👗 Odjeća i obuća' },
    { id: 4, name: '🛋️ Nameštaj i oprema' },
    { id: 5, name: '🎮 Igrice i konzole' },
    { id: 6, name: '📚 Knjige i hobiji' },
    { id: 7, name: '🐾 Kućni ljubimci' },
    { id: 8, name: '🔧 Alati i mašine' },
    { id: 9, name: '👶 Deca i bebe' },
    { id: 10, name: '💄 Lepota i zdravlje' },
    { id: 11, name: '🌿 Ostalo' },
];

export function getCategoryName(id: number): string {
    return CATEGORIES.find(cat => cat.id === id)?.name ?? 'Nepoznato';
}
