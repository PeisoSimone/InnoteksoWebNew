// ⚡ OPTIMIZED SERVICE WORKER FOR INNOTEKSO BLAZOR WASM
// Version: 1.0 - INCREMENT THIS ON EACH DEPLOYMENT!

const CACHE_VERSION = 'innotekso-v1.0';
const CACHE_NAME = `${CACHE_VERSION}-cache`;

// Critical resources to cache immediately
const PRECACHE_URLS = [
    '/',
    '/index.html',
    '/css/app.css',
    '/css/bootstrap.min.css',
    '/css/innotekso-styles.css',
    '/images/icon.webp',
];

// Patterns to cache on request
const CACHE_PATTERNS = [
    /\/_framework\//,
    /\.wasm$/,
    /\.dll$/,
    /\.js$/,
    /\.css$/,
    /\.webp$/,
    /\.png$/,
    /\.jpg$/,
];

// Never cache these
const NETWORK_ONLY = [
    /\/api\//,
    /formsubmit\.co/,
];

self.addEventListener('install', event => {
    console.log('[SW] Installing:', CACHE_VERSION);
    event.waitUntil(
        caches.open(CACHE_NAME)
            .then(cache => cache.addAll(PRECACHE_URLS))
            .then(() => self.skipWaiting())
    );
});

self.addEventListener('activate', event => {
    console.log('[SW] Activating:', CACHE_VERSION);
    event.waitUntil(
        caches.keys()
            .then(cacheNames => Promise.all(
                cacheNames
                    .filter(name => name.startsWith('innotekso-') && name !== CACHE_NAME)
                    .map(name => caches.delete(name))
            ))
            .then(() => self.clients.claim())
    );
});

self.addEventListener('fetch', event => {
    const { request } = event;
    const url = new URL(request.url);

    if (request.method !== 'GET' || url.origin !== self.location.origin) {
        return;
    }

    if (NETWORK_ONLY.some(pattern => pattern.test(request.url))) {
        event.respondWith(fetch(request));
        return;
    }

    const shouldCache = CACHE_PATTERNS.some(pattern => pattern.test(request.url));
    event.respondWith(shouldCache ? cacheFirst(request) : networkFirst(request));
});

async function cacheFirst(request) {
    const cached = await caches.match(request);
    if (cached) return cached;

    try {
        const response = await fetch(request);
        if (response.status === 200) {
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
        if (response.status === 200) {
            const cache = await caches.open(CACHE_NAME);
            cache.put(request, response.clone());
        }// ⚡ OPTIMIZED SERVICE WORKER FOR INNOTEKSO BLAZOR WASM
        // Version: 1.0 - INCREMENT THIS ON EACH DEPLOYMENT!

        const CACHE_VERSION = 'innotekso-v1.0';
        const CACHE_NAME = `${CACHE_VERSION}-cache`;

        // Critical resources to cache immediately
        const PRECACHE_URLS = [
            '/',
            '/index.html',
            '/css/app.css',
            '/css/bootstrap.min.css',
            '/css/innotekso-styles.css',
            '/images/icon.webp',
        ];

        // Patterns to cache on request
        const CACHE_PATTERNS = [
            /\/_framework\//,
            /\.wasm$/,
            /\.dll$/,
            /\.js$/,
            /\.css$/,
            /\.webp$/,
            /\.png$/,
            /\.jpg$/,
        ];

        // Never cache these
        const NETWORK_ONLY = [
            /\/api\//,
            /formsubmit\.co/,
        ];

        self.addEventListener('install', event => {
            console.log('[SW] Installing:', CACHE_VERSION);
            event.waitUntil(
                caches.open(CACHE_NAME)
                    .then(cache => cache.addAll(PRECACHE_URLS))
                    .then(() => self.skipWaiting())
            );
        });

        self.addEventListener('activate', event => {
            console.log('[SW] Activating:', CACHE_VERSION);
            event.waitUntil(
                caches.keys()
                    .then(cacheNames => Promise.all(
                        cacheNames
                            .filter(name => name.startsWith('innotekso-') && name !== CACHE_NAME)
                            .map(name => caches.delete(name))
                    ))
                    .then(() => self.clients.claim())
            );
        });

        self.addEventListener('fetch', event => {
            const { request } = event;
            const url = new URL(request.url);

            if (request.method !== 'GET' || url.origin !== self.location.origin) {
                return;
            }

            if (NETWORK_ONLY.some(pattern => pattern.test(request.url))) {
                event.respondWith(fetch(request));
                return;
            }

            const shouldCache = CACHE_PATTERNS.some(pattern => pattern.test(request.url));
            event.respondWith(shouldCache ? cacheFirst(request) : networkFirst(request));
        });

        async function cacheFirst(request) {
            const cached = await caches.match(request);
            if (cached) return cached;

            try {
                const response = await fetch(request);
                if (response.status === 200) {
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
                if (response.status === 200) {
                    const cache = await caches.open(CACHE_NAME);
                    cache.put(request, response.clone());
                }
                return response;
            } catch {
                return await caches.match(request) || new Response('Offline', { status: 503 });
            }
        }

        console.log('[SW] Loaded:', CACHE_VERSION);
        return response;
    } catch {
        return await caches.match(request) || new Response('Offline', { status: 503 });
    }
}

console.log('[SW] Loaded:', CACHE_VERSION);