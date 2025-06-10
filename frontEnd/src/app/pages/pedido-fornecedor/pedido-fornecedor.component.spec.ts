import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoFornecedorComponent } from './pedido-fornecedor.component';

describe('PedidoFornecedorComponent', () => {
  let component: PedidoFornecedorComponent;
  let fixture: ComponentFixture<PedidoFornecedorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PedidoFornecedorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PedidoFornecedorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
