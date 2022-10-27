from selenium.webdriver.support import expected_conditions as EC
EC.url_changes(current_url) # 检查URL是否改变
EC.url_to_be(new_url) # 检查重定向的URL
EC.url_contains('text') # 检查URL是否包含text
EC.url_matches() # 是否匹配
EC.title_is('New page Title') # 检查标题
EC.title_contains('text'
