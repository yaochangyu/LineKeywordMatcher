# LINE 關鍵字比對 BDD 測試計畫

## 步驟

- [x] **步驟 1：建立方案與專案結構**
  - 建立 .sln 方案檔
  - 建立類別庫專案 `LineKeywordMatcher`（放實作）
  - 建立 BDD 測試專案 `LineKeywordMatcher.Specs`（使用 SpecFlow + xUnit）
  - 設定專案參考關係

- [x] **步驟 2：撰寫 BDD 測試案例**
  - 建立 `.feature` 檔，以 Gherkin 語法定義情境
  - 涵蓋：標準寫法、大小寫、全形半形、空白、混合、不包含關鍵字等案例
  - 建立對應的 Step Definitions

- [x] **步驟 3：實作 Span 比對方法**
  - 在類別庫中實作第四種方法（Span<char> 手動掃描）
  - 包含全形轉半形、移除空白、轉小寫的正規化邏輯

- [x] **步驟 4：執行測試，確認全部綠燈**
  - 執行 `dotnet test`
  - 確認所有測試案例通過
