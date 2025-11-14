from flask import Flask, jsonify
from flask_cors import CORS
import requests
import time

app = Flask(__name__)
CORS(app)

# Кэш для хранения цен
price_cache = {}
CACHE_DURATION = 60  # секунды

def get_crypto_prices():
    """Получаем реальные цены криптовалют с CoinGecko"""
    global price_cache
    
    # Проверяем, есть ли актуальные данные в кэше
    current_time = time.time()
    if 'prices' in price_cache:
        data, timestamp = price_cache['prices']
        if current_time - timestamp < CACHE_DURATION:
            return data
    
    try:
        # Делаем запрос к CoinGecko API
        url = "https://api.coingecko.com/api/v3/simple/price"
        params = {
            'ids': 'bitcoin,ethereum,cardano,solana,polkadot',
            'vs_currencies': 'usd',
            'include_24hr_change': 'true'
        }
        
        response = requests.get(url, params=params, timeout=10)
        data = response.json()
        
        # Сохраняем в кэш
        price_cache['prices'] = (data, current_time)
        return data
        
    except Exception as e:
        print(f"Ошибка при получении цен: {e}")
        return {}

@app.route('/')
def home():
    return jsonify({
        "message": "DAMP API работает!",
        "version": "1.0",
        "endpoints": [
            "/api/assets",
            "/api/assets/with-prices",
            "/api/portfolios"
        ]
    })

@app.route('/api/assets')
def get_assets():
    """Возвращаем список активов"""
    assets = [
        {"id": 1, "name": "Bitcoin", "symbol": "BTC", "coingecko_id": "bitcoin"},
        {"id": 2, "name": "Ethereum", "symbol": "ETH", "coingecko_id": "ethereum"},
        {"id": 3, "name": "Cardano", "symbol": "ADA", "coingecko_id": "cardano"},
        {"id": 4, "name": "Solana", "symbol": "SOL", "coingecko_id": "solana"},
        {"id": 5, "name": "Polkadot", "symbol": "DOT", "coingecko_id": "polkadot"}
    ]
    return jsonify(assets)

@app.route('/api/assets/with-prices')
def get_assets_with_prices():
    """Возвращаем активы с текущими ценами"""
    assets = [
        {"id": 1, "name": "Bitcoin", "symbol": "BTC", "coingecko_id": "bitcoin"},
        {"id": 2, "name": "Ethereum", "symbol": "ETH", "coingecko_id": "ethereum"},
        {"id": 3, "name": "Cardano", "symbol": "ADA", "coingecko_id": "cardano"},
        {"id": 4, "name": "Solana", "symbol": "SOL", "coingecko_id": "solana"},
        {"id": 5, "name": "Polkadot", "symbol": "DOT", "coingecko_id": "polkadot"}
    ]
    
    # Получаем актуальные цены
    prices_data = get_crypto_prices()
    
    # Добавляем цены к активам
    for asset in assets:
        coin_id = asset['coingecko_id']
        if coin_id in prices_data:
            asset['price'] = prices_data[coin_id].get('usd', 0)
            asset['change'] = prices_data[coin_id].get('usd_24h_change', 0)
        else:
            asset['price'] = 0
            asset['change'] = 0
    
    return jsonify(assets)

@app.route('/api/portfolios')
def get_portfolios():
    """Возвращаем примеры портфелей"""
    portfolios = [
        {
            "id": 1,
            "name": "Консервативный портфель",
            "description": "Портфель с низким уровнем риска",
            "assets": [1, 2]  # BTC, ETH
        },
        {
            "id": 2,
            "name": "Рискованный портфель", 
            "description": "Портфель с высоким потенциалом роста",
            "assets": [3, 4, 5]  # ADA, SOL, DOT
        }
    ]
    return jsonify(portfolios)

if __name__ == '__main__':
    print("Запуск DAMP API...")
    print("API будет доступно по адресу: http://localhost:5000")
    print("Для остановки нажмите Ctrl+C")
    app.run(debug=True, host='0.0.0.0', port=5000)