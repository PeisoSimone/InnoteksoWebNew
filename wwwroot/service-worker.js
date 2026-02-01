// ═══════════════════════════════════════════════════════════════════
// SERVICE WORKER — Innotekso Blazor WASM
// ⚠️  INCREMENT CACHE_VERSION on every deployment to bust old caches
// ═══════════════════════════════════════════════════════════════════

const CACHE_VERSION = 'innotekso-v1.1';          // ← bump this each deploy
const CACHE_NAME = `${CACHE_VERSION}-cache`;

// ─── PRECACHE: resources needed before the app can paint ──────────
const PRECACHE_URLS = [
    '/',
    '/index.html',
    '/css/app.css',
    '/css/bootstrap.min.css',
    '/css/innotekso-styles.css',
    '/css/unified-consistent-styles.css',
    '/css/output.css',
    '/images/icon.webp',
];

// ─── CACHE-FIRST patterns: static, fingerprinted assets ──────────
const CACHE_FIRST_PATTERNS = [
    /\/_framework\//,       // Blazor runtime + WASM
    /\.wasm$/,
    /\.dll$/,
    /\.js$/,
    /\.css$/,
    /\.webp$/,
    /\.png$/,
    /\.jpg$/,
    /\.svg$/,
    /\.woff2?$/,
];

// ─── NETWORK-ONLY: never serve from cache ─────────────────────────
const NETWORK_ONLY_PATTERNS = [
    /\/api\//,              // any future API routes
    /formsubmit\.co/,       // email service
];

// ═══════════════════════════════════════════════════════════════════
// INSTALL — precache critical shell
// ═══════════════════════════════════════════════════════════════════
self.addEventListener('install', event => {
    event.waitUntil(
        caches.open(CACHE_NAME)
            .then(cache => cache.addAll(PRECACHE_URLS))
            .then(() => self.skipWaiting())
    );
});

// ═══════════════════════════════════════════════════════════════════
// ACTIVATE — purge stale caches from previous versions
// ═══════════════════════════════════════════════════════════════════
self.addEventListener('activate', event => {
    event.waitUntil(
        caches.keys().then(cacheNames =>
            Promise.all(
                cacheNames
                    .filter(name => name.startsWith('innotekso-') && name !== CACHE_NAME)
                    .map(name => caches.delete(name))
            )
        ).then(() => self.clients.claim())
    );
});

// ═══════════════════════════════════════════════════════════════════
// FETCH — route requests to the right strategy
// ═══════════════════════════════════════════════════════════════════
self.addEventListener('fetch', event => {
    const { request } = event;
    const url = new URL(request.url);

    // Only intercept same-origin GET requests
    if (request.method !== 'GET' || url.origin !== self.location.origin) {
        return;
    }

    // Network-only: skip cache entirely
    if (NETWORK_ONLY_PATTERNS.some(pattern => pattern.test(request.url))) {
        event.respondWith(fetch(request));
        return;
    }

    // Cache-first for known static assets; network-first for everything else
    const useCache = CACHE_FIRST_PATTERNS.some(pattern => pattern.test(request.url));
    event.respondWith(useCache ? cacheFirst(request) : networkFirst(request));
});

// ═══════════════════════════════════════════════════════════════════
// STRATEGIES
// ═══════════════════════════════════════════════════════════════════

async function cacheFirst(request) {
    const cached = await caches.match(request);
    if (cached) return cached;

    try {
        const response = await fetch(request);
        if (response.ok) {
            const cache = await caches.open(CACHE_NAME);
            cache.put(request, response.clone());
        }
        return response;
    } catch {
        return new Response('Offline', { status: 503 });
    }
}

async function networkFirst(request) {
    try {
        const response = await fetch(request);
        if (response.ok) {
            const cache = await caches.open(CACHE_NAME);
            cache.put(request, response.clone());
        }
        return response;
    } catch {
        return await caches.match(request) || new Response('Offline', { status: 503 });
    }
}